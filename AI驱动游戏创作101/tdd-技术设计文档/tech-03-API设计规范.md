# API设计规范

## 文档信息
- **文档编号**: TECH-03-API
- **文档名称**: API设计规范
- **版本**: v1.0
- **创建日期**: 2025-09-17
- **负责人**: 技术架构团队
- **审核状态**: 待审核

---

## 一、API设计原则

### 1.1 设计原则
- **一致性**: 统一的命名和设计模式
- **简洁性**: 接口简单明了，易于理解
- **可扩展性**: 支持功能扩展而不破坏现有代码
- **性能**: 考虑性能影响，避免不必要的开销
- **安全性**: 数据验证和错误处理

### 1.2 命名规范
```csharp
// 类名: PascalCase
public class PlayerController { }

// 方法名: PascalCase
public void CalculateDamage() { }

// 变量名: camelCase
private float playerHealth;

// 常量: SCREAMING_SNAKE_CASE
public const int MAX_HEALTH = 100;

// 接口: I前缀
public interface IDamageable { }

// 属性: PascalCase
public float CurrentHealth { get; set; }
```

### 1.3 文档标准
```csharp
/// <summary>
/// 玩家控制器类
/// </summary>
public class PlayerController : MonoBehaviour {
    /// <summary>
    /// 玩家移动速度
    /// </summary>
    [SerializeField] private float moveSpeed = 5f;

    /// <summary>
    /// 初始化玩家
    /// </summary>
    /// <param name="health">初始生命值</param>
    /// <param name="position">初始位置</param>
    public void InitializePlayer(float health, Vector2 position) { }
}
```

---

## 二、核心系统API

### 2.1 游戏管理器API
```csharp
/// <summary>
/// 游戏管理器 - 管理游戏全局状态
/// </summary>
public class GameManager : MonoBehaviour {
    // 单例模式
    public static GameManager Instance { get; private set; }

    // 游戏状态枚举
    public enum GameState {
        MainMenu,
        Playing,
        Paused,
        GameOver,
        Loading
    }

    // 当前游戏状态
    public GameState CurrentState { get; private set; }

    // 游戏初始化
    public void InitializeGame() { }

    // 开始新游戏
    public void StartNewGame() { }

    // 暂停游戏
    public void PauseGame() { }

    // 恢复游戏
    public void ResumeGame() { }

    // 保存游戏
    public void SaveGame(int slot) { }

    // 加载游戏
    public void LoadGame(int slot) { }

    // 退出游戏
    public void QuitGame() { }

    // 场景加载
    public void LoadScene(string sceneName, Action onComplete = null) { }

    // 游戏状态改变事件
    public event Action<GameState> OnGameStateChanged;
}
```

### 2.2 角色系统API
```csharp
/// <summary>
/// 角色基类
/// </summary>
public abstract class Character : MonoBehaviour, IDamageable {
    // 基础属性
    public abstract float MaxHealth { get; }
    public abstract float CurrentHealth { get; protected set; }
    public abstract float MoveSpeed { get; }
    public abstract float AttackPower { get; }
    public abstract float Defense { get; }

    // 角色状态
    public abstract bool IsAlive { get; }
    public abstract bool IsStunned { get; }
    public abstract bool IsInvincible { get; }

    // 角色控制
    public abstract void Move(Vector2 direction);
    public abstract void Attack();
    public abstract void Defend();
    public abstract void UseSkill(int skillId);
    public abstract void TakeDamage(float damage);
    public abstract void Heal(float amount);
    public abstract void Die();

    // 角色事件
    public event Action<float> OnHealthChanged;
    public event Action OnDeath;
    public event Action OnAttack;
    public event Action OnSkillUsed;
}

/// <summary>
/// 可伤害接口
/// </summary>
public interface IDamageable {
    float MaxHealth { get; }
    float CurrentHealth { get; }
    bool IsAlive { get; }

    void TakeDamage(float damage);
    void Heal(float amount);
    void Die();
}
```

### 2.3 战斗系统API
```csharp
/// <summary>
/// 战斗管理器
/// </summary>
public class CombatManager : MonoBehaviour {
    // 单例模式
    public static CombatManager Instance { get; private set; }

    // 伤害计算
    public float CalculateDamage(Character attacker, Character target, float baseDamage) {
        float damage = baseDamage * (attacker.AttackPower / target.Defense);
        return Mathf.Max(damage, 1f); // 最小伤害为1
    }

    // 技能伤害计算
    public float CalculateSkillDamage(Character attacker, Character target, Skill skill) {
        float skillDamage = skill.BaseDamage * (1 + attacker.AttackPower * 0.1f);
        return CalculateDamage(attacker, target, skillDamage);
    }

    // 暴击判定
    public bool IsCriticalHit(Character attacker) {
        float critChance = attacker.GetStatValue(StatType.CriticalChance);
        return Random.value < critChance;
    }

    // 命中判定
    public bool IsHit(Character attacker, Character target) {
        float accuracy = attacker.GetStatValue(StatType.Accuracy);
        float evasion = target.GetStatValue(StatType.Evasion);
        float hitChance = accuracy / (accuracy + evasion);
        return Random.value < hitChance;
    }

    // 应用状态效果
    public void ApplyStatusEffect(Character target, StatusEffect effect) {
        target.AddStatusEffect(effect);
    }

    // 战斗事件
    public event Action<Character, Character, float> OnDamageDealt;
    public event Action<Character, Character> OnCharacterDeath;
    public event Action<Character, Skill> OnSkillUsed;
}
```

### 2.4 装备系统API
```csharp
/// <summary>
/// 装备数据结构
/// </summary>
[System.Serializable]
public class EquipmentData {
    public string equipmentId;
    public string equipmentName;
    public EquipmentType equipmentType;
    public EquipmentRarity rarity;
    public EquipmentStats stats;
    public string description;
    public Sprite icon;
    public int level;
    public int maxLevel;
}

/// <summary>
/// 装备类型枚举
/// </summary>
public enum EquipmentType {
    Weapon,
    Armor,
    Accessory1,
    Accessory2
}

/// <summary>
/// 装备稀有度枚举
/// </summary>
public enum EquipmentRarity {
    Common,
    Uncommon,
    Rare,
    Epic
}

/// <summary>
/// 装备管理器
/// </summary>
public class EquipmentManager : MonoBehaviour {
    // 单例模式
    public static EquipmentManager Instance { get; private set; }

    // 装备槽位
    private Dictionary<EquipmentType, EquipmentData> equipmentSlots;

    // 装备道具
    public bool EquipItem(EquipmentData equipment) {
        if (CanEquip(equipment)) {
            equipmentSlots[equipment.equipmentType] = equipment;
            ApplyEquipmentStats(equipment);
            return true;
        }
        return false;
    }

    // 卸下装备
    public bool UnequipItem(EquipmentType type) {
        if (equipmentSlots.ContainsKey(type)) {
            var equipment = equipmentSlots[type];
            RemoveEquipmentStats(equipment);
            equipmentSlots.Remove(type);
            return true;
        }
        return false;
    }

    // 检查是否可以装备
    public bool CanEquip(EquipmentData equipment) {
        return equipment.level <= PlayerController.Instance.Level;
    }

    // 应用装备属性
    private void ApplyEquipmentStats(EquipmentData equipment) {
        var player = PlayerController.Instance;
        player.AddStatModifier(StatType.AttackPower, equipment.stats.attackPower);
        player.AddStatModifier(StatType.Defense, equipment.stats.defense);
        // ...其他属性
    }

    // 移除装备属性
    private void RemoveEquipmentStats(EquipmentData equipment) {
        var player = PlayerController.Instance;
        player.RemoveStatModifier(StatType.AttackPower, equipment.stats.attackPower);
        player.RemoveStatModifier(StatType.Defense, equipment.stats.defense);
        // ...其他属性
    }

    // 获取装备
    public EquipmentData GetEquipment(EquipmentType type) {
        return equipmentSlots.ContainsKey(type) ? equipmentSlots[type] : null;
    }
}
```

---

## 三、数据管理API

### 3.1 数据存储系统
```csharp
/// <summary>
/// 数据管理器
/// </summary>
public class DataManager : MonoBehaviour {
    // 单例模式
    public static DataManager Instance { get; private set; }

    // 保存游戏数据
    public void SaveGame(int slot) {
        GameData gameData = new GameData {
            playerData = PlayerController.Instance.GetPlayerData(),
            inventoryData = InventoryManager.Instance.GetInventoryData(),
            equipmentData = EquipmentManager.Instance.GetEquipmentData(),
            questData = QuestManager.Instance.GetQuestData(),
            currentScene = SceneManager.GetActiveScene().name,
            playTime = GameManager.Instance.PlayTime
        };

        string jsonData = JsonUtility.ToJson(gameData, true);
        string filePath = Path.Combine(Application.persistentDataPath, $"save_{slot}.json");
        File.WriteAllText(filePath, jsonData);

        // 加密保存数据
        EncryptAndSaveFile(filePath, jsonData);
    }

    // 加载游戏数据
    public bool LoadGame(int slot) {
        string filePath = Path.Combine(Application.persistentDataPath, $"save_{slot}.json");
        if (File.Exists(filePath)) {
            string encryptedData = File.ReadAllText(filePath);
            string jsonData = DecryptFile(encryptedData);
            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);

            // 验证数据完整性
            if (ValidateGameData(gameData)) {
                // 加载数据到各个系统
                PlayerController.Instance.LoadPlayerData(gameData.playerData);
                InventoryManager.Instance.LoadInventoryData(gameData.inventoryData);
                EquipmentManager.Instance.LoadEquipmentData(gameData.equipmentData);
                QuestManager.Instance.LoadQuestData(gameData.questData);

                return true;
            }
        }
        return false;
    }

    // 数据验证
    private bool ValidateGameData(GameData data) {
        return data != null &&
               data.playerData != null &&
               data.inventoryData != null &&
               data.equipmentData != null &&
               data.questData != null;
    }
}

/// <summary>
/// 游戏数据结构
/// </summary>
[System.Serializable]
public class GameData {
    public PlayerData playerData;
    public InventoryData inventoryData;
    public EquipmentData equipmentData;
    public QuestData questData;
    public string currentScene;
    public float playTime;
}
```

### 3.2 配置数据管理
```csharp
/// <summary>
/// 配置管理器
/// </summary>
public class ConfigManager : MonoBehaviour {
    // 单例模式
    public static ConfigManager Instance { get; private set; }

    // 角色配置
    [SerializeField] private CharacterConfig[] characterConfigs;

    // 技能配置
    [SerializeField] private SkillConfig[] skillConfigs;

    // 装备配置
    [SerializeField] private EquipmentConfig[] equipmentConfigs;

    // 关卡配置
    [SerializeField] private LevelConfig[] levelConfigs;

    // 获取角色配置
    public CharacterConfig GetCharacterConfig(string characterId) {
        return Array.Find(characterConfigs, config => config.characterId == characterId);
    }

    // 获取技能配置
    public SkillConfig GetSkillConfig(string skillId) {
        return Array.Find(skillConfigs, config => config.skillId == skillId);
    }

    // 获取装备配置
    public EquipmentConfig GetEquipmentConfig(string equipmentId) {
        return Array.Find(equipmentConfigs, config => config.equipmentId == equipmentId);
    }

    // 获取关卡配置
    public LevelConfig GetLevelConfig(string levelId) {
        return Array.Find(levelConfigs, config => config.levelId == levelId);
    }
}

/// <summary>
/// 角色配置数据结构
/// </summary>
[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Game/CharacterConfig")]
public class CharacterConfig : ScriptableObject {
    public string characterId;
    public string characterName;
    public float maxHealth;
    public float moveSpeed;
    public float attackPower;
    public float defense;
    public GameObject characterPrefab;
    public Sprite characterSprite;
    public AudioClip[] voiceClips;
}
```

---

## 四、UI系统API

### 4.1 UI管理器
```csharp
/// <summary>
/// UI管理器
/// </summary>
public class UIManager : MonoBehaviour {
    // 单例模式
    public static UIManager Instance { get; private set; }

    // UI层级枚举
    public enum UILayer {
        Background,
        Normal,
        Popup,
        Top
    }

    // UI窗口字典
    private Dictionary<string, GameObject> uiWindows;

    // 显示UI窗口
    public void ShowWindow(string windowName, bool animate = true) {
        if (uiWindows.ContainsKey(windowName)) {
            var window = uiWindows[windowName];
            window.SetActive(true);

            if (animate) {
                // 播放显示动画
                PlayShowAnimation(window);
            }
        }
    }

    // 隐藏UI窗口
    public void HideWindow(string windowName, bool animate = true) {
        if (uiWindows.ContainsKey(windowName)) {
            var window = uiWindows[windowName];

            if (animate) {
                // 播放隐藏动画
                PlayHideAnimation(window, () => {
                    window.SetActive(false);
                });
            } else {
                window.SetActive(false);
            }
        }
    }

    // 注册UI窗口
    public void RegisterWindow(string windowName, GameObject window) {
        if (!uiWindows.ContainsKey(windowName)) {
            uiWindows.Add(windowName, window);
        }
    }

    // 注销UI窗口
    public void UnregisterWindow(string windowName) {
        if (uiWindows.ContainsKey(windowName)) {
            uiWindows.Remove(windowName);
        }
    }

    // UI事件注册
    public void RegisterUIEvent(string eventName, UnityAction action) {
        // 实现UI事件系统
    }

    // UI事件注销
    public void UnregisterUIEvent(string eventName, UnityAction action) {
        // 实现UI事件系统
    }
}
```

### 4.2 UI更新接口
```csharp
/// <summary>
/// UI更新接口
/// </summary>
public interface IUIUpdateHandler {
    void UpdateUI();
    void RefreshData();
    void OnLanguageChanged();
}

/// <summary>
/// 玩家状态UI控制器
/// </summary>
public class PlayerStatusUI : MonoBehaviour, IUIUpdateHandler {
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider manaSlider;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;

    // 更新UI
    public void UpdateUI() {
        var player = PlayerController.Instance;

        healthSlider.value = player.CurrentHealth / player.MaxHealth;
        manaSlider.value = player.CurrentMana / player.MaxMana;
        levelText.text = $"Level {player.Level}";
        expText.text = $"{player.CurrentExp}/{player.ExpToNextLevel}";
    }

    // 刷新数据
    public void RefreshData() {
        UpdateUI();
    }

    // 语言改变时更新
    public void OnLanguageChanged() {
        // 更新文本显示
        UpdateUI();
    }

    // 监听玩家事件
    private void OnEnable() {
        PlayerController.Instance.OnHealthChanged += OnHealthChanged;
        PlayerController.Instance.OnLevelUp += OnLevelUp;
    }

    private void OnDisable() {
        PlayerController.Instance.OnHealthChanged -= OnHealthChanged;
        PlayerController.Instance.OnLevelUp -= OnLevelUp;
    }

    private void OnHealthChanged(float health) {
        UpdateUI();
    }

    private void OnLevelUp(int level) {
        UpdateUI();
    }
}
```

---

## 五、音频系统API

### 5.1 音频管理器
```csharp
/// <summary>
/// 音频管理器
/// </summary>
public class AudioManager : MonoBehaviour {
    // 单例模式
    public static AudioManager Instance { get; private set; }

    // 音频类型枚举
    public enum AudioType {
        BackgroundMusic,
        SoundEffect,
        VoiceOver,
        Ambient,
        UI
    }

    // 音频源
    private AudioSource musicSource;
    private AudioSource[] sfxSources;
    private Queue<AudioSource> availableSfxSources;

    // 音频库
    private Dictionary<string, AudioClip> audioClips;

    // 初始化
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeAudioSources();
            LoadAudioClips();
        } else {
            Destroy(gameObject);
        }
    }

    // 初始化音频源
    private void InitializeAudioSources() {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

        sfxSources = new AudioSource[10];
        availableSfxSources = new Queue<AudioSource>();

        for (int i = 0; i < sfxSources.Length; i++) {
            sfxSources[i] = gameObject.AddComponent<AudioSource>();
            availableSfxSources.Enqueue(sfxSources[i]);
        }
    }

    // 播放背景音乐
    public void PlayMusic(string clipName, bool loop = true) {
        if (audioClips.ContainsKey(clipName)) {
            musicSource.clip = audioClips[clipName];
            musicSource.loop = loop;
            musicSource.Play();
        }
    }

    // 播放音效
    public void PlaySFX(string clipName, Vector3 position = default) {
        if (audioClips.ContainsKey(clipName) && availableSfxSources.Count > 0) {
            AudioSource source = availableSfxSources.Dequeue();
            source.clip = audioClips[clipName];
            source.transform.position = position;
            source.Play();

            StartCoroutine(ReturnSFXSource(source));
        }
    }

    // 播放语音
    public void PlayVoice(string clipName) {
        PlaySFX(clipName);
    }

    // 停止音乐
    public void StopMusic(float fadeDuration = 1f) {
        StartCoroutine(FadeOutMusic(fadeDuration));
    }

    // 设置音量
    public void SetMusicVolume(float volume) {
        musicSource.volume = Mathf.Clamp01(volume);
    }

    public void SetSFXVolume(float volume) {
        foreach (var source in sfxSources) {
            source.volume = Mathf.Clamp01(volume);
        }
    }

    // 返回音效源到池中
    private IEnumerator ReturnSFXSource(AudioSource source) {
        yield return new WaitWhile(() => source.isPlaying);
        availableSfxSources.Enqueue(source);
    }

    // 音乐淡出
    private IEnumerator FadeOutMusic(float duration) {
        float startVolume = musicSource.volume;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume;
    }
}
```

---

## 六、输入系统API

### 6.1 输入管理器
```csharp
/// <summary>
/// 输入管理器
/// </summary>
public class InputManager : MonoBehaviour {
    // 单例模式
    public static InputManager Instance { get; private set; }

    // 输入动作
    private PlayerControls playerControls;

    // 输入状态
    public Vector2 MoveInput { get; private set; }
    public bool IsAttacking { get; private set; }
    public bool IsDefending { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsInteracting { get; private set; }

    // 输入事件
    public event Action OnAttackPressed;
    public event Action OnDefendPressed;
    public event Action OnDefendReleased;
    public event Action OnJumpPressed;
    public event Action OnInteractPressed;
    public event Action OnPausePressed;

    // 初始化
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeInput();
        } else {
            Destroy(gameObject);
        }
    }

    // 初始化输入系统
    private void InitializeInput() {
        playerControls = new PlayerControls();

        // 移动输入
        playerControls.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        playerControls.Player.Move.canceled += ctx => MoveInput = Vector2.zero;

        // 攻击输入
        playerControls.Player.Attack.performed += ctx => {
            IsAttacking = true;
            OnAttackPressed?.Invoke();
        };
        playerControls.Player.Attack.canceled += ctx => IsAttacking = false;

        // 防御输入
        playerControls.Player.Defend.performed += ctx => {
            IsDefending = true;
            OnDefendPressed?.Invoke();
        };
        playerControls.Player.Defend.canceled += ctx => {
            IsDefending = false;
            OnDefendReleased?.Invoke();
        };

        // 跳跃输入
        playerControls.Player.Jump.performed += ctx => {
            IsJumping = true;
            OnJumpPressed?.Invoke();
        };
        playerControls.Player.Jump.canceled += ctx => IsJumping = false;

        // 交互输入
        playerControls.Player.Interact.performed += ctx => {
            IsInteracting = true;
            OnInteractPressed?.Invoke();
        };
        playerControls.Player.Interact.canceled += ctx => IsInteracting = false;

        // 暂停输入
        playerControls.Player.Pause.performed += ctx => OnPausePressed?.Invoke();

        // 启用输入
        playerControls.Enable();
    }

    // 启用/禁用玩家输入
    public void EnablePlayerInput(bool enable) {
        if (enable) {
            playerControls.Player.Enable();
        } else {
            playerControls.Player.Disable();
        }
    }

    // 启用/禁用UI输入
    public void EnableUIInput(bool enable) {
        if (enable) {
            playerControls.UI.Enable();
        } else {
            playerControls.UI.Disable();
        }
    }

    // 清理
    private void OnDestroy() {
        if (playerControls != null) {
            playerControls.Disable();
        }
    }
}
```

---

## 七、事件系统API

### 7.1 事件管理器
```csharp
/// <summary>
/// 事件管理器
/// </summary>
public static class EventManager {
    // 事件字典
    private static Dictionary<string, List<Action<object>>> eventListeners =
        new Dictionary<string, List<Action<object>>>();

    // 注册事件监听器
    public static void AddListener(string eventName, Action<object> listener) {
        if (!eventListeners.ContainsKey(eventName)) {
            eventListeners[eventName] = new List<Action<object>>();
        }

        if (!eventListeners[eventName].Contains(listener)) {
            eventListeners[eventName].Add(listener);
        }
    }

    // 移除事件监听器
    public static void RemoveListener(string eventName, Action<object> listener) {
        if (eventListeners.ContainsKey(eventName)) {
            eventListeners[eventName].Remove(listener);

            if (eventListeners[eventName].Count == 0) {
                eventListeners.Remove(eventName);
            }
        }
    }

    // 触发事件
    public static void TriggerEvent(string eventName, object data = null) {
        if (eventListeners.ContainsKey(eventName)) {
            var listeners = new List<Action<object>>(eventListeners[eventName]);

            foreach (var listener in listeners) {
                try {
                    listener?.Invoke(data);
                } catch (Exception e) {
                    Debug.LogError($"Error in event listener for {eventName}: {e.Message}");
                }
            }
        }
    }

    // 清理所有事件监听器
    public static void ClearAllListeners() {
        eventListeners.Clear();
    }
}

/// <summary>
/// 游戏事件常量
/// </summary>
public static class GameEvents {
    // 玩家事件
    public const string PlayerHealthChanged = "PlayerHealthChanged";
    public const string PlayerLevelUp = "PlayerLevelUp";
    public const string PlayerDeath = "PlayerDeath";
    public const string PlayerRespawn = "PlayerRespawn";

    // 战斗事件
    public const string EnemyDefeated = "EnemyDefeated";
    public const string BossDefeated = "BossDefeated";
    public const string CombatStarted = "CombatStarted";
    public const string CombatEnded = "CombatEnded";

    // 任务事件
    public const string QuestStarted = "QuestStarted";
    public const string QuestCompleted = "QuestCompleted";
    public const string QuestFailed = "QuestFailed";

    // 物品事件
    public const string ItemCollected = "ItemCollected";
    public const string ItemUsed = "ItemUsed";
    public const string ItemEquipped = "ItemEquipped";

    // 系统事件
    public const string GamePaused = "GamePaused";
    public const string GameResumed = "GameResumed";
    public const string SceneLoaded = "SceneLoaded";
    public const string GameSaved = "GameSaved";
    public const string GameLoaded = "GameLoaded";
}
```

---

## 八、性能优化API

### 8.1 对象池管理器
```csharp
/// <summary>
/// 对象池管理器
/// </summary>
public class ObjectPoolManager : MonoBehaviour {
    // 单例模式
    public static ObjectPoolManager Instance { get; private set; }

    // 对象池字典
    private Dictionary<string, Queue<GameObject>> objectPools =
        new Dictionary<string, Queue<GameObject>>();

    // 预制体字典
    private Dictionary<string, GameObject> prefabs =
        new Dictionary<string, GameObject>();

    // 初始化
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // 注册预制体
    public void RegisterPrefab(string prefabName, GameObject prefab) {
        if (!prefabs.ContainsKey(prefabName)) {
            prefabs[prefabName] = prefab;
        }
    }

    // 获取对象
    public GameObject GetObject(string prefabName, Vector3 position = default, Quaternion rotation = default) {
        if (!prefabs.ContainsKey(prefabName)) {
            Debug.LogError($"Prefab {prefabName} not registered!");
            return null;
        }

        GameObject obj = null;

        // 尝试从池中获取
        if (objectPools.ContainsKey(prefabName) && objectPools[prefabName].Count > 0) {
            obj = objectPools[prefabName].Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
        } else {
            // 创建新对象
            obj = Instantiate(prefabs[prefabName], position, rotation);
            obj.name = prefabName;
        }

        return obj;
    }

    // 返回对象到池中
    public void ReturnObject(GameObject obj) {
        string prefabName = obj.name.Replace("(Clone)", "");

        if (!objectPools.ContainsKey(prefabName)) {
            objectPools[prefabName] = new Queue<GameObject>();
        }

        obj.SetActive(false);
        objectPools[prefabName].Enqueue(obj);
    }

    // 预加载对象池
    public void PreloadPool(string prefabName, int count) {
        if (!prefabs.ContainsKey(prefabName)) {
            Debug.LogError($"Prefab {prefabName} not registered!");
            return;
        }

        if (!objectPools.ContainsKey(prefabName)) {
            objectPools[prefabName] = new Queue<GameObject>();
        }

        for (int i = 0; i < count; i++) {
            GameObject obj = Instantiate(prefabs[prefabName]);
            obj.SetActive(false);
            objectPools[prefabName].Enqueue(obj);
        }
    }

    // 清理对象池
    public void ClearPool(string prefabName) {
        if (objectPools.ContainsKey(prefabName)) {
            while (objectPools[prefabName].Count > 0) {
                Destroy(objectPools[prefabName].Dequeue());
            }
            objectPools.Remove(prefabName);
        }
    }

    // 清理所有对象池
    public void ClearAllPools() {
        foreach (var pool in objectPools.Values) {
            while (pool.Count > 0) {
                Destroy(pool.Dequeue());
            }
        }
        objectPools.Clear();
    }
}
```

---

## 九、调试工具API

### 9.1 调试管理器
```csharp
/// <summary>
/// 调试管理器
/// </summary>
public class DebugManager : MonoBehaviour {
    // 单例模式
    public static DebugManager Instance { get; private set; }

    // 调试模式
    public bool IsDebugMode { get; private set; }

    // 调试命令
    private Dictionary<string, Action<string[]>> debugCommands =
        new Dictionary<string, Action<string[]>>();

    // 调试信息
    private Dictionary<string, string> debugInfo =
        new Dictionary<string, string>();

    // 初始化
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeDebugCommands();
        } else {
            Destroy(gameObject);
        }
    }

    // 初始化调试命令
    private void InitializeDebugCommands() {
        // 生命值命令
        debugCommands["sethealth"] = (args) => {
            if (args.Length > 0 && float.TryParse(args[0], out float health)) {
                PlayerController.Instance.SetHealth(health);
                LogDebug($"Set player health to {health}");
            }
        };

        // 传送命令
        debugCommands["teleport"] = (args) => {
            if (args.Length >= 2 && float.TryParse(args[0], out float x) && float.TryParse(args[1], out float y)) {
                PlayerController.Instance.transform.position = new Vector3(x, y, 0);
                LogDebug($"Teleported to ({x}, {y})");
            }
        };

        // 给予物品命令
        debugCommands["giveitem"] = (args) => {
            if (args.Length > 0) {
                string itemId = args[0];
                int count = args.Length > 1 && int.TryParse(args[1], out int c) ? c : 1;
                InventoryManager.Instance.AddItem(itemId, count);
                LogDebug($"Gave {count} of item {itemId}");
            }
        };

        // 完成任务命令
        debugCommands["completequest"] = (args) => {
            if (args.Length > 0) {
                string questId = args[0];
                QuestManager.Instance.CompleteQuest(questId);
                LogDebug($"Completed quest {questId}");
            }
        };
    }

    // 执行调试命令
    public void ExecuteCommand(string command) {
        string[] parts = command.Split(' ');
        string commandName = parts[0].ToLower();
        string[] args = parts.Skip(1).ToArray();

        if (debugCommands.ContainsKey(commandName)) {
            debugCommands[commandName](args);
        } else {
            LogDebug($"Unknown command: {commandName}");
        }
    }

    // 记录调试信息
    public void LogDebug(string message) {
        if (IsDebugMode) {
            Debug.Log($"[DEBUG] {message}");
            debugInfo["last_command"] = message;
        }
    }

    // 切换调试模式
    public void ToggleDebugMode() {
        IsDebugMode = !IsDebugMode;
        LogDebug($"Debug mode {(IsDebugMode ? "enabled" : "disabled")}");
    }

    // 获取调试信息
    public string GetDebugInfo(string key) {
        return debugInfo.ContainsKey(key) ? debugInfo[key] : "";
    }

    // 设置调试信息
    public void SetDebugInfo(string key, string value) {
        debugInfo[key] = value;
    }
}
```

---

## 十、总结

这个API设计规范提供了完整的系统接口定义，涵盖了游戏开发的所有核心方面：

1. **一致性**: 统一的命名规范和设计模式
2. **模块化**: 每个系统都有清晰的接口定义
3. **可扩展性**: 支持功能扩展而不破坏现有代码
4. **事件驱动**: 完整的事件系统支持松耦合通信
5. **性能优化**: 包含对象池等性能优化机制
6. **调试支持**: 提供完整的调试工具和命令系统

这个API设计为后续的具体实现提供了坚实的基础，确保代码的可维护性和可扩展性。
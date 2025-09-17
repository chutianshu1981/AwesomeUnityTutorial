# 数据库设计文档

## 文档信息
- **文档编号**: TECH-04-DATABASE
- **文档名称**: 数据库设计文档
- **版本**: v1.0
- **创建日期**: 2025-09-17
- **负责人**: 技术架构团队
- **审核状态**: 待审核

---

## 一、数据库架构概述

### 1.1 数据存储策略
本项目采用**文件存储 + 内存缓存**的混合策略，针对2D像素ARPG游戏的特点进行优化：

- **配置数据**: ScriptableObject + JSON文件
- **运行时数据**: JSON文件存储 + 内存缓存
- **存档数据**: 加密JSON文件
- **临时数据**: 内存缓存

### 1.2 数据层次结构
```
┌─────────────────────────────────────────┐
│              应用层 (Application Layer)    │
├─────────────────────────────────────────┤
│              数据访问层 (Data Access Layer) │
├─────────────────────────────────────────┤
│              数据存储层 (Storage Layer)     │
│  ┌─────────────┬─────────────┬─────────────┐ │
│  │   配置数据   │   存档数据   │   临时数据   │ │
│  │ Scriptable  │   JSON      │   Memory    │ │
│  │ Objects     │   Files     │   Cache     │ │
│  └─────────────┴─────────────┴─────────────┘ │
└─────────────────────────────────────────┘
```

### 1.3 数据管理原则
- **一致性**: 数据结构统一，避免冗余
- **完整性**: 数据验证和错误处理
- **性能**: 快速加载和查询
- **安全性**: 存档数据加密
- **可扩展性**: 支持功能扩展

---

## 二、配置数据设计

### 2.1 角色配置数据结构
```csharp
// CharacterConfig.cs
[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Game/CharacterConfig")]
public class CharacterConfig : ScriptableObject {
    [Header("基本信息")]
    public string characterId;
    public string characterName;
    public string description;
    public Sprite characterSprite;

    [Header("属性配置")]
    public float maxHealth = 100f;
    public float maxMana = 50f;
    public float moveSpeed = 5f;
    public float attackPower = 10f;
    public float defense = 5f;
    public float criticalChance = 0.1f;
    public float attackSpeed = 1f;

    [Header("成长配置")]
    public float healthPerLevel = 10f;
    public float manaPerLevel = 5f;
    public float attackPerLevel = 2f;
    public float defensePerLevel = 1f;

    [Header("预制体配置")]
    public GameObject characterPrefab;
    public RuntimeAnimatorController animatorController;

    [Header("音频配置")]
    public AudioClip attackSound;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioClip[] voiceClips;
}

// 角色升级经验配置
[CreateAssetMenu(fileName = "LevelExpConfig", menuName = "Game/LevelExpConfig")]
public class LevelExpConfig : ScriptableObject {
    public int maxLevel = 30;
    public int[] expRequirements;

    public int GetExpRequirement(int level) {
        if (level <= 0 || level > maxLevel) return 0;
        return expRequirements[level - 1];
    }
}
```

### 2.2 技能配置数据结构
```csharp
// SkillConfig.cs
[CreateAssetMenu(fileName = "SkillConfig", menuName = "Game/SkillConfig")]
public class SkillConfig : ScriptableObject {
    [Header("技能信息")]
    public string skillId;
    public string skillName;
    public string description;
    public Sprite skillIcon;

    [Header("技能类型")]
    public SkillType skillType;
    public DamageType damageType;
    public TargetType targetType;

    [Header("技能属性")]
    public float baseDamage = 20f;
    public float manaCost = 10f;
    public float cooldown = 5f;
    public float castTime = 0f;
    public float range = 5f;
    public int maxLevel = 5;

    [Header("效果配置")]
    public GameObject skillEffectPrefab;
    public AudioClip castSound;
    public AnimationClip castAnimation;

    [Header("升级效果")]
    public float damageIncreasePerLevel = 5f;
    public float manaCostIncreasePerLevel = 2f;
    public float cooldownDecreasePerLevel = 0.5f;

    [Header("状态效果")]
    public StatusEffectConfig[] statusEffects;
}

public enum SkillType {
    Active,
    Passive,
    Ultimate
}

public enum DamageType {
    Physical,
    Magical,
    TrueDamage
}

public enum TargetType {
    Self,
    Enemy,
    Ally,
    Area,
    All
}
```

### 2.3 装备配置数据结构
```csharp
// EquipmentConfig.cs
[CreateAssetMenu(fileName = "EquipmentConfig", menuName = "Game/EquipmentConfig")]
public class EquipmentConfig : ScriptableObject {
    [Header("装备信息")]
    public string equipmentId;
    public string equipmentName;
    public string description;
    public EquipmentType equipmentType;
    public EquipmentRarity rarity;
    public Sprite equipmentIcon;

    [Header("装备属性")]
    public int level = 1;
    public int maxLevel = 10;
    public float attackPower = 0f;
    public float defense = 0f;
    public float health = 0f;
    public float mana = 0f;
    public float criticalChance = 0f;
    public float attackSpeed = 0f;
    public float moveSpeed = 0f;

    [Header("强化配置")]
    public float baseEnhanceBonus = 0.1f;
    public float enhanceBonusPerLevel = 0.05f;
    public int[] enhanceCosts;
    public float[] enhanceSuccessRates;

    [Header("套装配置")]
    public string setBonusId;
    public int setBonusRequired = 2;
    public EquipmentSetBonus[] setBonuses;

    [Header="预制体配置")]
    public GameObject equipmentPrefab;
    public AudioClip equipSound;
}

public enum EquipmentType {
    Weapon,
    Armor,
    Accessory1,
    Accessory2
}

public enum EquipmentRarity {
    Common,
    Uncommon,
    Rare,
    Epic
}

[System.Serializable]
public class EquipmentSetBonus {
    public int requiredCount;
    public float attackPowerBonus;
    public float defenseBonus;
    public float healthBonus;
    public string description;
}
```

### 2.4 物品配置数据结构
```csharp
// ItemConfig.cs
[CreateAssetMenu(fileName = "ItemConfig", menuName = "Game/ItemConfig")]
public class ItemConfig : ScriptableObject {
    [Header("物品信息")]
    public string itemId;
    public string itemName;
    public string description;
    public ItemType itemType;
    public ItemRarity rarity;
    public Sprite itemIcon;
    public int maxStackSize = 99;

    [Header("物品属性")]
    public int value = 10;
    public float weight = 0.1f;
    public bool isConsumable = false;
    public bool isTradeable = true;
    public bool isSellable = true;

    [Header("使用效果")]
    public ItemEffect[] effects;
    public AudioClip useSound;
    public GameObject useEffectPrefab;

    [Header="商店配置")]
    public bool canBeSold = true;
    public int buyPrice = 10;
    public int sellPrice = 5;
    public bool unlimitedStock = true;
    public int stock = 0;
}

public enum ItemType {
    Consumable,
    Equipment,
    Material,
    Quest,
    Currency
}

public enum ItemRarity {
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

[System.Serializable]
public class ItemEffect {
    public EffectType effectType;
    public float value;
    public float duration;
    public TargetType targetType;
}

public enum EffectType {
    Heal,
    ManaRestore,
    Buff,
    Debuff,
    Revive
}
```

### 2.5 关卡配置数据结构
```csharp
// LevelConfig.cs
[CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/LevelConfig")]
public class LevelConfig : ScriptableObject {
    [Header("关卡信息")]
    public string levelId;
    public string levelName;
    public string description;
    public string sceneName;
    public Sprite levelThumbnail;

    [Header("关卡配置")]
    public LevelType levelType;
    public int recommendedLevel = 1;
    public int maxLevel = 30;
    public float timeLimit = 0f; // 0为无限制

    [Header("敌人生成")]
    public EnemySpawn[] enemySpawns;
    public BossSpawn[] bossSpawns;

    [Header("任务配置")]
    public QuestObjective[] objectives;
    public QuestReward[] rewards;

    [Header="环境配置")]
    public AmbientLightSettings ambientLight;
    public BackgroundMusicSettings backgroundMusic;
    public WeatherSettings weather;
}

[System.Serializable]
public class EnemySpawn {
    public string enemyId;
    public Vector2 spawnPosition;
    public int count = 1;
    public float spawnDelay = 0f;
    public bool isElite = false;
}

[System.Serializable]
public class BossSpawn {
    public string bossId;
    public Vector2 spawnPosition;
    public string[] phases;
    public float[] phaseHealthThresholds;
}

[System.Serializable]
public class QuestObjective {
    public ObjectiveType objectiveType;
    public string targetId;
    public int requiredCount = 1;
    public string description;
}

[System.Serializable]
public class QuestReward {
    public RewardType rewardType;
    public string rewardId;
    public int amount = 1;
}

public enum LevelType {
    Story,
    Side,
    Challenge,
    Boss
}

public enum ObjectiveType {
    KillEnemy,
    CollectItem,
    ReachLocation,
    TalkToNPC,
    Survive
}

public enum RewardType {
    Experience,
    Gold,
    Item,
    Equipment
}
```

---

## 三、存档数据设计

### 3.1 存档主数据结构
```csharp
// SaveData.cs
[System.Serializable]
public class SaveData {
    [Header("存档信息")]
    public string saveId;
    public string saveName;
    public DateTime saveTime;
    public string version;
    public int playTimeSeconds;
    public string currentScene;

    [Header("玩家数据")]
    public PlayerSaveData playerData;

    [Header("游戏进度")]
    public GameProgressData gameProgress;

    [Header("背包数据")]
    public InventorySaveData inventoryData;

    [Header("装备数据")]
    public EquipmentSaveData equipmentData;

    [Header("任务数据")]
    public QuestSaveData questData;

    [Header("系统数据")]
    public SystemSaveData systemData;

    // 数据验证
    public bool ValidateData() {
        return playerData != null &&
               gameProgress != null &&
               inventoryData != null &&
               equipmentData != null &&
               questData != null &&
               systemData != null;
    }
}

// 玩家存档数据
[System.Serializable]
public class PlayerSaveData {
    public string playerId;
    public string playerName;
    public int level;
    public float currentHealth;
    public float currentMana;
    public float currentExp;
    public Vector2 position;
    public string equippedWeaponId;
    public string equippedArmorId;
    public string equippedAccessory1Id;
    public string equippedAccessory2Id;

    // 属性数据
    public float maxHealth;
    public float maxMana;
    public float attackPower;
    public float defense;
    public float criticalChance;
    public float attackSpeed;
    public float moveSpeed;

    // 技能数据
    public List<SkillSaveData> skills;

    // 状态数据
    public List<StatusEffectSaveData> statusEffects;
}

// 游戏进度数据
[System.Serializable]
public class GameProgressData {
    public int currentChapter;
    public int currentLevel;
    public List<string> completedChapters;
    public List<string> completedLevels;
    public List<string> unlockedAreas;
    public List<string> unlockedFeatures;
    public Dictionary<string, bool> flags;
    public Dictionary<string, float> variables;
}

// 背包存档数据
[System.Serializable]
public class InventorySaveData {
    public List<ItemSaveData> items;
    public int maxSlots = 30;
    public int gold;
    public int gems;

    // 物品槽位数据
    public List<ItemSlotSaveData> itemSlots;
}

// 装备存档数据
[System.Serializable]
public class EquipmentSaveData {
    public List<EquipmentItemSaveData> equipmentItems;
    public Dictionary<string, int> equipmentEnhanceLevels;
}

// 任务存档数据
[System.Serializable]
public class QuestSaveData {
    public List<QuestProgressSaveData> activeQuests;
    public List<string> completedQuests;
    public List<string> failedQuests;
}

// 系统存档数据
[System.Serializable]
public class SystemSaveData {
    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
    public bool subtitlesEnabled = true;
    public string language = "zh-CN";
    public List<string> unlockedAchievements;
    public Dictionary<string, int> statistics;
}

// 技能存档数据
[System.Serializable]
public class SkillSaveData {
    public string skillId;
    public int level;
    public float currentCooldown;
    public bool isUnlocked;
}

// 状态效果存档数据
[System.Serializable]
public class StatusEffectSaveData {
    public string effectId;
    public float remainingDuration;
    public float intensity;
}

// 物品存档数据
[System.Serializable]
public class ItemSaveData {
    public string itemId;
    public int count;
    public int slotIndex;

    // 物品特定数据
    public Dictionary<string, object> customData;
}

// 装备物品存档数据
[System.Serializable]
public class EquipmentItemSaveData {
    public string equipmentId;
    public int enhanceLevel;
    public string customName;
    public List<string> customEnchants;
}

// 任务进度存档数据
[System.Serializable]
public class QuestProgressSaveData {
    public string questId;
    public QuestStatus status;
    public List<ObjectiveProgressSaveData> objectives;
    public DateTime startTime;
    public DateTime? completeTime;
}

// 目标进度存档数据
[System.Serializable]
public class ObjectiveProgressSaveData {
    public string objectiveId;
    public int currentProgress;
    public int requiredProgress;
    public bool isCompleted;
}

// 物品槽位存档数据
[System.Serializable]
public class ItemSlotSaveData {
    public int slotIndex;
    public string itemId;
    public int count;
    public bool isEmpty;
}

public enum QuestStatus {
    NotStarted,
    InProgress,
    Completed,
    Failed,
    Abandoned
}
```

### 3.2 存档管理器
```csharp
// SaveManager.cs
public class SaveManager : MonoBehaviour {
    // 单例模式
    public static SaveManager Instance { get; private set; }

    // 存档路径
    private string savePath;

    // 加密密钥
    private string encryptionKey = "SongDynastyARPG2024";

    // 初始化
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Path.Combine(Application.persistentDataPath, "Saves");
            InitializeSaveDirectory();
        } else {
            Destroy(gameObject);
        }
    }

    // 初始化存档目录
    private void InitializeSaveDirectory() {
        if (!Directory.Exists(savePath)) {
            Directory.CreateDirectory(savePath);
        }
    }

    // 创建新存档
    public SaveData CreateNewSave(string saveName) {
        SaveData saveData = new SaveData {
            saveId = Guid.NewGuid().ToString(),
            saveName = saveName,
            saveTime = DateTime.Now,
            version = Application.version,
            playTimeSeconds = 0,
            currentScene = "MainMenu",
            playerData = CreateInitialPlayerData(),
            gameProgress = CreateInitialProgressData(),
            inventoryData = CreateInitialInventoryData(),
            equipmentData = CreateInitialEquipmentData(),
            questData = CreateInitialQuestData(),
            systemData = CreateInitialSystemData()
        };

        return saveData;
    }

    // 保存游戏
    public bool SaveGame(SaveData saveData) {
        try {
            saveData.saveTime = DateTime.Now;
            saveData.currentScene = SceneManager.GetActiveScene().name;

            // 序列化数据
            string jsonData = JsonUtility.ToJson(saveData, true);

            // 加密数据
            string encryptedData = EncryptData(jsonData, encryptionKey);

            // 保存到文件
            string filePath = Path.Combine(savePath, $"{saveData.saveId}.sav");
            File.WriteAllText(filePath, encryptedData);

            // 创建备份
            CreateBackup(saveData);

            return true;
        } catch (Exception e) {
            Debug.LogError($"Save failed: {e.Message}");
            return false;
        }
    }

    // 加载游戏
    public SaveData LoadGame(string saveId) {
        try {
            string filePath = Path.Combine(savePath, $"{saveId}.sav");

            if (!File.Exists(filePath)) {
                return null;
            }

            // 读取加密数据
            string encryptedData = File.ReadAllText(filePath);

            // 解密数据
            string jsonData = DecryptData(encryptedData, encryptionKey);

            // 反序列化数据
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);

            // 验证数据
            if (saveData != null && saveData.ValidateData()) {
                return saveData;
            } else {
                Debug.LogError("Invalid save data!");
                return null;
            }
        } catch (Exception e) {
            Debug.LogError($"Load failed: {e.Message}");
            return null;
        }
    }

    // 获取存档列表
    public List<SaveData> GetSaveList() {
        List<SaveData> saveList = new List<SaveData>();

        if (!Directory.Exists(savePath)) {
            return saveList;
        }

        string[] saveFiles = Directory.GetFiles(savePath, "*.sav");

        foreach (string saveFile in saveFiles) {
            try {
                string encryptedData = File.ReadAllText(saveFile);
                string jsonData = DecryptData(encryptedData, encryptionKey);
                SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);

                if (saveData != null) {
                    saveList.Add(saveData);
                }
            } catch (Exception e) {
                Debug.LogWarning($"Failed to load save file {saveFile}: {e.Message}");
            }
        }

        return saveList.OrderByDescending(s => s.saveTime).ToList();
    }

    // 删除存档
    public bool DeleteSave(string saveId) {
        try {
            string filePath = Path.Combine(savePath, $"{saveId}.sav");

            if (File.Exists(filePath)) {
                File.Delete(filePath);
                return true;
            }

            return false;
        } catch (Exception e) {
            Debug.LogError($"Delete failed: {e.Message}");
            return false;
        }
    }

    // 数据加密
    private string EncryptData(string data, string key) {
        // 使用AES加密
        // 这里简化处理，实际项目中应该使用更安全的加密方式
        byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
        byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));

        using (Aes aes = Aes.Create()) {
            aes.Key = keyBytes;
            aes.IV = new byte[16]; // 初始化向量

            using (MemoryStream ms = new MemoryStream()) {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)) {
                    cs.Write(dataBytes, 0, dataBytes.Length);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    // 数据解密
    private string DecryptData(string encryptedData, string key) {
        // 使用AES解密
        byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
        byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));

        using (Aes aes = Aes.Create()) {
            aes.Key = keyBytes;
            aes.IV = new byte[16]; // 初始化向量

            using (MemoryStream ms = new MemoryStream()) {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write)) {
                    cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                }
                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }

    // 创建备份
    private void CreateBackup(SaveData saveData) {
        try {
            string backupPath = Path.Combine(savePath, "Backups");
            if (!Directory.Exists(backupPath)) {
                Directory.CreateDirectory(backupPath);
            }

            string backupFileName = $"{saveData.saveId}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string backupFilePath = Path.Combine(backupPath, backupFileName);

            string jsonData = JsonUtility.ToJson(saveData, true);
            string encryptedData = EncryptData(jsonData, encryptionKey);

            File.WriteAllText(backupFilePath, encryptedData);

            // 清理旧备份（保留最近5个）
            var backupFiles = Directory.GetFiles(backupPath, $"{saveData.saveId}_*.bak")
                .OrderBy(f => f)
                .ToList();

            while (backupFiles.Count > 5) {
                File.Delete(backupFiles[0]);
                backupFiles.RemoveAt(0);
            }
        } catch (Exception e) {
            Debug.LogWarning($"Backup failed: {e.Message}");
        }
    }

    // 创建初始玩家数据
    private PlayerSaveData CreateInitialPlayerData() {
        return new PlayerSaveData {
            playerId = "player_001",
            playerName = "玩家",
            level = 1,
            currentHealth = 100f,
            currentMana = 50f,
            currentExp = 0f,
            position = Vector2.zero,
            equippedWeaponId = "",
            equippedArmorId = "",
            equippedAccessory1Id = "",
            equippedAccessory2Id = "",
            maxHealth = 100f,
            maxMana = 50f,
            attackPower = 10f,
            defense = 5f,
            criticalChance = 0.1f,
            attackSpeed = 1f,
            moveSpeed = 5f,
            skills = new List<SkillSaveData>(),
            statusEffects = new List<StatusEffectSaveData>()
        };
    }

    // 创建初始进度数据
    private GameProgressData CreateInitialProgressData() {
        return new GameProgressData {
            currentChapter = 1,
            currentLevel = 1,
            completedChapters = new List<string>(),
            completedLevels = new List<string>(),
            unlockedAreas = new List<string>(),
            unlockedFeatures = new List<string>(),
            flags = new Dictionary<string, bool>(),
            variables = new Dictionary<string, float>()
        };
    }

    // 创建初始背包数据
    private InventorySaveData CreateInitialInventoryData() {
        return new InventorySaveData {
            items = new List<ItemSaveData>(),
            maxSlots = 30,
            gold = 100,
            gems = 0,
            itemSlots = new List<ItemSlotSaveData>()
        };
    }

    // 创建初始装备数据
    private EquipmentSaveData CreateInitialEquipmentData() {
        return new EquipmentSaveData {
            equipmentItems = new List<EquipmentItemSaveData>(),
            equipmentEnhanceLevels = new Dictionary<string, int>()
        };
    }

    // 创建初始任务数据
    private QuestSaveData CreateInitialQuestData() {
        return new QuestSaveData {
            activeQuests = new List<QuestProgressSaveData>(),
            completedQuests = new List<string>(),
            failedQuests = new List<string>()
        };
    }

    // 创建初始系统数据
    private SystemSaveData CreateInitialSystemData() {
        return new SystemSaveData {
            masterVolume = 1f,
            musicVolume = 1f,
            sfxVolume = 1f,
            subtitlesEnabled = true,
            language = "zh-CN",
            unlockedAchievements = new List<string>(),
            statistics = new Dictionary<string, int>()
        };
    }
}
```

---

## 四、数据验证和完整性检查

### 4.1 数据验证器
```csharp
// DataValidator.cs
public static class DataValidator {
    // 验证存档数据
    public static bool ValidateSaveData(SaveData saveData) {
        if (saveData == null) return false;
        if (string.IsNullOrEmpty(saveData.saveId)) return false;
        if (string.IsNullOrEmpty(saveData.saveName)) return false;
        if (saveData.playerData == null) return false;
        if (saveData.gameProgress == null) return false;
        if (saveData.inventoryData == null) return false;
        if (saveData.equipmentData == null) return false;
        if (saveData.questData == null) return false;
        if (saveData.systemData == null) return false;

        // 验证玩家数据
        if (!ValidatePlayerData(saveData.playerData)) return false;

        // 验证进度数据
        if (!ValidateProgressData(saveData.gameProgress)) return false;

        // 验证背包数据
        if (!ValidateInventoryData(saveData.inventoryData)) return false;

        // 验证装备数据
        if (!ValidateEquipmentData(saveData.equipmentData)) return false;

        // 验证任务数据
        if (!ValidateQuestData(saveData.questData)) return false;

        // 验证系统数据
        if (!ValidateSystemData(saveData.systemData)) return false;

        return true;
    }

    // 验证玩家数据
    private static bool ValidatePlayerData(PlayerSaveData playerData) {
        if (playerData.level < 1 || playerData.level > 30) return false;
        if (playerData.currentHealth < 0) return false;
        if (playerData.currentMana < 0) return false;
        if (playerData.currentExp < 0) return false;
        if (playerData.maxHealth <= 0) return false;
        if (playerData.maxMana < 0) return false;
        if (playerData.attackPower < 0) return false;
        if (playerData.defense < 0) return false;
        if (playerData.criticalChance < 0 || playerData.criticalChance > 1) return false;
        if (playerData.attackSpeed <= 0) return false;
        if (playerData.moveSpeed <= 0) return false;

        return true;
    }

    // 验证进度数据
    private static bool ValidateProgressData(GameProgressData progressData) {
        if (progressData.currentChapter < 1) return false;
        if (progressData.currentLevel < 1) return false;

        return true;
    }

    // 验证背包数据
    private static bool ValidateInventoryData(InventorySaveData inventoryData) {
        if (inventoryData.gold < 0) return false;
        if (inventoryData.gems < 0) return false;
        if (inventoryData.maxSlots <= 0) return false;

        return true;
    }

    // 验证装备数据
    private static bool ValidateEquipmentData(EquipmentSaveData equipmentData) {
        // 验证强化等级
        foreach (var enhanceLevel in equipmentData.equipmentEnhanceLevels) {
            if (enhanceLevel.Value < 0 || enhanceLevel.Value > 15) return false;
        }

        return true;
    }

    // 验证任务数据
    private static bool ValidateQuestData(QuestSaveData questData) {
        // 验证任务进度
        foreach (var quest in questData.activeQuests) {
            if (string.IsNullOrEmpty(quest.questId)) return false;
            if (quest.objectives == null) return false;

            foreach (var objective in quest.objectives) {
                if (objective.currentProgress < 0) return false;
                if (objective.requiredProgress <= 0) return false;
            }
        }

        return true;
    }

    // 验证系统数据
    private static bool ValidateSystemData(SystemSaveData systemData) {
        if (systemData.masterVolume < 0 || systemData.masterVolume > 1) return false;
        if (systemData.musicVolume < 0 || systemData.musicVolume > 1) return false;
        if (systemData.sfxVolume < 0 || systemData.sfxVolume > 1) return false;

        return true;
    }
}
```

---

## 五、性能优化策略

### 5.1 数据加载优化
```csharp
// DataLoadOptimizer.cs
public class DataLoadOptimizer : MonoBehaviour {
    // 异步加载配置数据
    public IEnumerator LoadConfigAsync<T>(string path, Action<T> onComplete) where T : ScriptableObject {
        // 使用Addressables或Resources.LoadAsync异步加载
        ResourceRequest request = Resources.LoadAsync<T>(path);

        yield return request;

        if (request.asset != null) {
            T config = request.asset as T;
            onComplete?.Invoke(config);
        } else {
            Debug.LogError($"Failed to load config: {path}");
        }
    }

    // 批量加载配置数据
    public IEnumerator LoadConfigsAsync<T>(string[] paths, Action<List<T>> onComplete) where T : ScriptableObject {
        List<T> configs = new List<T>();
        List<Coroutine> loadCoroutines = new List<Coroutine>();

        foreach (string path in paths) {
            loadCoroutines.Add(StartCoroutine(LoadConfigAsync<T>(path, (config) => {
                if (config != null) {
                    configs.Add(config);
                }
            })));
        }

        // 等待所有加载完成
        foreach (var coroutine in loadCoroutines) {
            yield return coroutine;
        }

        onComplete?.Invoke(configs);
    }

    // 缓存管理
    private Dictionary<string, ScriptableObject> configCache = new Dictionary<string, ScriptableObject>();

    public T GetCachedConfig<T>(string path) where T : ScriptableObject {
        if (configCache.ContainsKey(path)) {
            return configCache[path] as T;
        }

        T config = Resources.Load<T>(path);
        if (config != null) {
            configCache[path] = config;
        }

        return config;
    }

    // 清理缓存
    public void ClearCache() {
        configCache.Clear();
        Resources.UnloadUnusedAssets();
    }
}
```

### 5.2 内存管理
```csharp
// MemoryManager.cs
public class MemoryManager : MonoBehaviour {
    // 内存监控
    private void Update() {
        // 定期检查内存使用情况
        if (Time.frameCount % 300 == 0) { // 每5秒检查一次
            CheckMemoryUsage();
        }
    }

    // 检查内存使用
    private void CheckMemoryUsage() {
        long totalMemory = GC.GetTotalMemory(false);
        long workingSet = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64;

        if (workingSet > 1024 * 1024 * 1024) { // 超过1GB
            OptimizeMemory();
        }
    }

    // 内存优化
    private void OptimizeMemory() {
        // 清理未使用的资源
        Resources.UnloadUnusedAssets();

        // 强制垃圾回收
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // 优化对象池
        ObjectPoolManager.Instance.ClearAllPools();

        // 清理缓存
        DataLoadOptimizer.Instance.ClearCache();

        Debug.Log("Memory optimization completed");
    }

    // 场景切换时清理内存
    public void OnSceneUnloaded() {
        // 清理场景相关的资源
        Resources.UnloadUnusedAssets();
        GC.Collect();
    }
}
```

---

## 六、总结

这个数据库设计提供了完整的数据管理解决方案，包含了：

1. **配置数据管理**: 使用ScriptableObject和JSON文件管理游戏配置
2. **存档数据管理**: 完整的存档系统，支持加密和备份
3. **数据验证**: 全面的数据验证和完整性检查
4. **性能优化**: 异步加载、缓存管理、内存优化
5. **安全性**: 数据加密和备份机制
6. **可扩展性**: 支持新功能和数据类型扩展

这个设计为2D像素ARPG游戏提供了稳定、高效、安全的数据管理基础。
# Sprite 相关处理

## 1. 读取 Multiply 格式中的指定 Sprite

```C#
//获取整个图片文件中的所有 Sprite,并存入数组中
Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath("Assets/Sprites/LevelAssets/0x72_16x16DungeonTileset.v4.png").OfType<Sprite>().ToArray();

//遍历并获取指定名称 Sprite
foreach (Sprite sprite in sprites)
{
    if (sprite == null)
    {
        Debug.Log("sprite 未找到....");
    }
    else
    {
        Debug.Log(sprite);
        if (sprite.name.Equals("chest_01"))
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
            Debug.Log("更换箱子图片，玩家获取100G");
        }
    }
}

```

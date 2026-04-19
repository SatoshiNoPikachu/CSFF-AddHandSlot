# 缩小卡牌（CardSizeReduce）- CSFF MOD



## 简介

缩小卡牌（CardSizeReduce）是一个综合功能类Mod。

功能如下：

游戏中新增了两种特质：增加手牌槽位；增加负重上限。

修改手牌槽位数量（需选用特质，或在配置文件中使用 “强制增加手牌槽位的数量” 功能）。

修改玩家的负重上限（需选用特质，或在配置文件中使用 “强制修改负重上限” 功能）。

UI优化：

- 可滚动卡牌检查窗口动作按钮

翻页功能：

- 蓝图分类按钮（仅顶级分类）

缩小以下槽位尺寸（部分需在配置文件中手动启用）：

- 环境槽位
- 基地槽位
- 手牌槽位
- 蓝图槽位
- 容器槽位
- 装备槽位（伤口/魔法槽位）

双行槽位（部分需在配置文件中手动启用）：

- 环境槽位
- 基地槽位
- 手牌槽位
- 蓝图槽位
- 容器槽位
- 装备槽位（伤口/魔法槽位）

特殊功能：

- 容器动态双行槽位



<u>有关配置文件的内容，详情请看配置说明。</u>

强烈建议使用 Bepinex 插件 ConfigurationManager 修改配置项！



当前版本：3.3.0

By.サトシの皮卡丘



## 安装说明

需安装前置模组：模组核心(ModCore) v3.1.1+。

请将模组压缩包解压于 BepInEx\plugins 文件夹下。

> Tips：更新模组时，需先删除旧版本模组文件后再解压。

> Tips：如果出现模组不运行的问题，请删除 BepInEx/cache 目录后再启动游戏。



## 配置说明

配置文件：BepInEx\config\Pikachu.CSFF.CardSizeReduce.cfg

注意：该文件需要至少运行一次本Mod才会生成，修改后重启游戏生效！

另外，可以使用插件 Configuration Manager 修改配置（在游戏中按 F1 打开配置界面）。



### 增加手牌槽位的数量

类别：Config

键名：AddHandSlotNum

范围：-6-10000（默认为 6）

说明：值为负数时，实际效果为减少手牌槽位数量。



### 强制增加手牌槽位的数量

类别：Config

键名：ForceAddHandSlot

范围：true（启用），false（禁用，默认）

说明：启用后，将会修改下次打开存档的手牌槽位数量（根据配置项 “增加手牌槽位的数量”），生效后会立即自动禁用本项。



### 强制修改负重上限

类别：Config

键名：ForceModifyEncumbrance

范围：true（启用），false（禁用，默认）

说明：启用后，将会修改下次打开存档的负重上限（根据配置项 “增加负重上限的值”），生效后会立即自动禁用本项。



### 增加负重上限的值

类别：Config

键名：AddEncumbranceNum

范围：-3999-1000000000（默认为 6000）

说明：值为负数时，实际效果为减少负重上限。



### 双行环境槽位

类别：DoubleLine

键名：EnableLocation

范围：true（启用，默认），false（禁用）

说明：开启后将强制修改环境槽位的尺寸。



### 双行基地槽位

类别：DoubleLine

键名：EnableBase

范围：true（启用，默认），false（禁用）

说明：开启后将强制修改基地槽位的尺寸。



### 双行手牌槽位

类别：DoubleLine

键名：EnableHand

范围：true（启用），false（禁用，默认）

说明：开启后将强制修改手牌槽位的尺寸。



### 双行蓝图槽位

类别：DoubleLine

键名：EnableBlueprint

范围：true（启用，默认），false（禁用）

说明：体验版功能，待优化。开启后将强制修改蓝图槽位的尺寸。



### 双行容器槽位

类别：DoubleLine

键名：EnableInventory

范围：true（启用，默认），false（禁用）

说明：开启后将强制修改容器槽位的尺寸。



### 双行装备槽位

类别：DoubleLine

键名：EnableEquipment

范围：true（启用，默认），false（禁用）

说明：开启后将强制修改装备槽位的尺寸。



### 修改环境槽位的尺寸

类别：SlotScale

键名：EnableLocation

范围：true（启用，默认），false（禁用）



### 修改基地槽位的尺寸

类别：SlotScale

键名：EnableBase

范围：true（启用，默认），false（禁用）



### 修改手牌槽位的尺寸

类别：SlotScale

键名：EnableHand

范围：true（启用），false（禁用，默认）



### 修改蓝图槽位的尺寸

类别：SlotScale

键名：EnableBlueprint

范围：true（启用，默认），false（禁用）



### 修改容器槽位的尺寸

类别：SlotScale

键名：EnableInventory

范围：true（启用，默认），false（禁用）



### 修改装备槽位的尺寸

类别：SlotScale

键名：EnableEquipment

范围：true（启用，默认），false（禁用）



### 容器动态双行槽位

类别：Special

键名：EnableInventoryDynamicDoubleLine

范围：true（启用，默认），false（禁用）

说明：需同时启用双行容器槽位生效，启用后仅当容器槽位数量大于8时才会按双行显示。



## 更新日志

### Version 3.3.0

- 项目重建：为适配模组核心v3版本，从 CSTI 版本重新移植实现。
- 修复蓝图翻页按钮的位置偏移。
- 重新实现“修改负重上限”功能，以适配 CSFF 原生状态上限修改功能。
- 使用 ModEditor for ModCore 重写数据，将由模组核心负责自动加载。
  - 所有 UID 修改为模组核心对象命名格式。
  - 特质已转移至体格分类中。
  - 负重上限状态现在表示增量，因此现在值范围是 -3999-1000000000。
- 部分功能优化、修改或移除。



### Version 1.0.5

修复导致游戏状态值异常的问题（已知导致体感温度异常）。



### Version 1.0.4

实装“可滚动卡牌检查窗口动作按钮”功能。



### Version 1.0.3

- 优化 “双行蓝图槽位” 功能显示效果。
- 配置项“双行容器槽位”、“修改蓝图槽位的尺寸”现在恢复默认开启。
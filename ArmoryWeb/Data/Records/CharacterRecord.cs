namespace ArmoryWeb.Data.Records;

public class CharacterRecord
{
    public _Links _links { get; set; }
    public Character character { get; set; }
    public Equipped_Item[] equipped_items { get; set; }
    public Equipped_Item_Set[] equipped_item_sets { get; set; }
}

public class _Links
{
    public Self self { get; set; }
}

public class Self
{
    public string href { get; set; }
}

public class Character
{
    public Key key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
    public Realm realm { get; set; }
}

public class Key
{
    public string href { get; set; }
}

public class Realm
{
    public Key1 key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
    public string slug { get; set; }
}

public class Key1
{
    public string href { get; set; }
}

public class Equipped_Item
{
    public Item item { get; set; }
    public Slot slot { get; set; }
    public int quantity { get; set; }
    public int context { get; set; }
    public int[] bonus_list { get; set; }
    public Quality quality { get; set; }
    public string name { get; set; }
    public Media media { get; set; }
    public Item_Class item_class { get; set; }
    public Item_Subclass item_subclass { get; set; }
    public Inventory_Type inventory_type { get; set; }
    public Binding binding { get; set; }
    public Armor armor { get; set; }
    public Stat[] stats { get; set; }
    public Sell_Price sell_price { get; set; }
    public Requirements requirements { get; set; }
    public Level1 level { get; set; }
    public Durability durability { get; set; }
    public Name_Description name_description { get; set; }
    public bool is_subclass_hidden { get; set; }
    public Set set { get; set; }
    public Enchantment[] enchantments { get; set; }
    public Socket[] sockets { get; set; }
    public string unique_equipped { get; set; }
    public Spell[] spells { get; set; }
    public string limit_category { get; set; }
    public string description { get; set; }
    public Weapon weapon { get; set; }
    public Shield_Block shield_block { get; set; }
    public Modified_Crafting_Stat[] modified_crafting_stat { get; set; }
}

public class Item
{
    public Key2 key { get; set; }
    public int id { get; set; }
}

public class Key2
{
    public string href { get; set; }
}

public class Slot
{
    public string type { get; set; }
    public string name { get; set; }
}

public class Quality
{
    public string type { get; set; }
    public string name { get; set; }
}

public class Media
{
    public Key3 key { get; set; }
    public int id { get; set; }
}

public class Key3
{
    public string href { get; set; }
}

public class Item_Class
{
    public Key4 key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
}

public class Key4
{
    public string href { get; set; }
}

public class Item_Subclass
{
    public Key5 key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
}

public class Key5
{
    public string href { get; set; }
}

public class Inventory_Type
{
    public string type { get; set; }
    public string name { get; set; }
}

public class Binding
{
    public string type { get; set; }
    public string name { get; set; }
}

public class Armor
{
    public int value { get; set; }
    public Display display { get; set; }
}

public class Display
{
    public string display_string { get; set; }
    public Color color { get; set; }
}

public class Color
{
    public int r { get; set; }
    public int g { get; set; }
    public int b { get; set; }
    public int a { get; set; }
}

public class Sell_Price
{
    public int value { get; set; }
    public Display_Strings display_strings { get; set; }
}

public class Display_Strings
{
    public string header { get; set; }
    public string gold { get; set; }
    public string silver { get; set; }
    public string copper { get; set; }
}

public class Requirements
{
    public Level level { get; set; }
}

public class Level
{
    public int value { get; set; }
    public string display_string { get; set; }
}

public class Level1
{
    public int value { get; set; }
    public string display_string { get; set; }
}

public class Durability
{
    public int value { get; set; }
    public string display_string { get; set; }
}

public class Name_Description
{
    public string display_string { get; set; }
    public Color1 color { get; set; }
}

public class Color1
{
    public int r { get; set; }
    public int g { get; set; }
    public int b { get; set; }
    public int a { get; set; }
}

public class Set
{
    public Item_Set item_set { get; set; }
    public Item1[] items { get; set; }
    public Effect[] effects { get; set; }
    public string display_string { get; set; }
}

public class Item_Set
{
    public Key6 key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
}

public class Key6
{
    public string href { get; set; }
}

public class Item1
{
    public Item2 item { get; set; }
    public bool is_equipped { get; set; }
}

public class Item2
{
    public Key7 key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
}

public class Key7
{
    public string href { get; set; }
}

public class Effect
{
    public string display_string { get; set; }
    public int required_count { get; set; }
}

public class Weapon
{
    public Damage damage { get; set; }
    public Attack_Speed attack_speed { get; set; }
    public Dps dps { get; set; }
}

public class Damage
{
    public int min_value { get; set; }
    public int max_value { get; set; }
    public string display_string { get; set; }
    public Damage_Class damage_class { get; set; }
}

public class Damage_Class
{
    public string type { get; set; }
    public string name { get; set; }
}

public class Attack_Speed
{
    public int value { get; set; }
    public string display_string { get; set; }
}

public class Dps
{
    public float value { get; set; }
    public string display_string { get; set; }
}

public class Shield_Block
{
    public int value { get; set; }
    public Display1 display { get; set; }
}

public class Display1
{
    public string display_string { get; set; }
    public Color2 color { get; set; }
}

public class Color2
{
    public int r { get; set; }
    public int g { get; set; }
    public int b { get; set; }
    public int a { get; set; }
}

public class Stat
{
    public Type type { get; set; }
    public int value { get; set; }
    public Display2 display { get; set; }
    public bool is_negated { get; set; }
    public bool is_equip_bonus { get; set; }
}

public class Type
{
    public string type { get; set; }
    public string name { get; set; }
}

public class Display2
{
    public string display_string { get; set; }
    public Color3 color { get; set; }
}

public class Color3
{
    public int r { get; set; }
    public int g { get; set; }
    public int b { get; set; }
    public int a { get; set; }
}

public class Enchantment
{
    public string display_string { get; set; }
    public int enchantment_id { get; set; }
    public Enchantment_Slot enchantment_slot { get; set; }
}

public class Enchantment_Slot
{
    public int id { get; set; }
    public string type { get; set; }
}

public class Socket
{
    public Socket_Type socket_type { get; set; }
}

public class Socket_Type
{
    public string type { get; set; }
    public string name { get; set; }
}

public class Spell
{
    public Spell1 spell { get; set; }
    public string description { get; set; }
}

public class Spell1
{
    public Key8 key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
}

public class Key8
{
    public string href { get; set; }
}

public class Modified_Crafting_Stat
{
    public int id { get; set; }
    public string type { get; set; }
    public string name { get; set; }
}

public class Equipped_Item_Set
{
    public Item_Set1 item_set { get; set; }
    public Item3[] items { get; set; }
    public Effect1[] effects { get; set; }
    public string display_string { get; set; }
}

public class Item_Set1
{
    public Key9 key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
}

public class Key9
{
    public string href { get; set; }
}

public class Item3
{
    public Item4 item { get; set; }
    public bool is_equipped { get; set; }
}

public class Item4
{
    public Key10 key { get; set; }
    public string name { get; set; }
    public int id { get; set; }
}

public class Key10
{
    public string href { get; set; }
}

public class Effect1
{
    public string display_string { get; set; }
    public int required_count { get; set; }
}

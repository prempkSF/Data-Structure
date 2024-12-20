
namespace DictionaryDS
{
    //Key Value Pair inside the _array is a Class of any type TypeKey TypeValue
    public class KeyValue<TKey,TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
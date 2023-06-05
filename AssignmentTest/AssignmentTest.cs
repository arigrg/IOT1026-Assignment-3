using Assignment;

namespace AssignmentTest
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);

            Assert.AreEqual(pack.GetMaxCount(), PackMaxItems);
        }

        [TestMethod]
        public void VolumeOverflowTest()
        {
            const int PackMaxItems = 1000;
            const float PackMaxVolume = 5;
            const float PackMaxWeight = 3000;

            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            Assert.AreEqual(pack.Add(new Bow()), true);
            Assert.AreEqual(pack.Add(new Bow()), false);
        }

        private class TestClassAttribute : Attribute
        {
        }

        private class TestMethodAttribute : Attribute
        {
        }

        private class Assert
        {
            internal static void AreEqual(int v, int packMaxItems)
            {
                throw new NotImplementedException();
            }

            internal static void AreEqual(bool v1, bool v2)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class Pack
    {
        private InventoryItem[] _items;
        private readonly int _maxCount;
        private readonly float _maxVolume;
        private readonly float _maxWeight;
        private int _currentCount;
        private float _currentVolume;
        private float _currentWeight;

        public Pack() : this(10, 20, 30) { }

        public Pack(int maxCount, float maxVolume, float maxWeight)
        {
            _items = new InventoryItem[maxCount];
            _maxCount = maxCount;
            _maxVolume = maxVolume;
            _maxWeight = maxWeight;
        }

        public int GetMaxCount()
        {
            return _maxCount;
        }

        public float GetVolume()
        {
            return _currentVolume;
        }

        public bool Add(InventoryItem item)
        {
            float weight = item.GetWeight();
            float volume = item.GetVolume();
            if (_currentCount < _maxCount && _currentVolume + volume <= _maxVolume && _currentWeight + weight <= _maxWeight)
            {
                _items[_currentCount] = item;
                _currentCount++;
                _currentVolume += volume;
                _currentWeight += weight;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("Pack Contents:");
            for (int i = 0; i < _currentCount; i++)
            {
                sb.AppendLine(_items[i].Display());
            }
            return sb.ToString();
        }

        private class StringBuilder
        {
            internal void AppendLine(string v)
            {
                throw new NotImplementedException();
            }
        }
    }

    public abstract class InventoryItem
    {
        private readonly float _volume;
        private readonly float _weight;

        protected InventoryItem(float volume, float weight)
        {
            if (volume <= 0f || weight <= 0f)
            {
                throw new ArgumentOutOfRangeException($"An item can't have {volume} volume or {weight} weight");
            }
            _volume = volume;
            _weight = weight;
        }

        public abstract string Display();

        public float GetVolume()
        {
            return _volume;
        }

        public float GetWeight()
        {
            return _weight;
        }
    }

    public class Bow : InventoryItem
    {
        public Bow() : base(1f, 4f) { }

        public override string Display()
        {
            return $"A bow with weight {GetWeight()} and volume {GetVolume()}";
        }
    }
}

using Hashmapu;

namespace Unit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            HashMap<int, int> dictionary = new HashMap<int, int>();

            dictionary.Add(10, 20);
            dictionary.Add(20, 30);
            dictionary.Add(30, 40);
            Assert.Throws<Exception>(() => dictionary.Add(30, 40));
            dictionary.Remove(10);
            dictionary.Clear();
            Assert.False(dictionary.Contains(10));
            Assert.False(dictionary.Contains(20));
            Assert.False(dictionary.Contains(30));

        }
    }
}
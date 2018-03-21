using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo2.RedisTypesOperations;

namespace Demo2
{
    internal class RedisDemo
    {
        public async Task Run()
        {
            await DemoString();
            await DemoList();
            DemoSet();
            DemoSortedSet();
            DemoHash();
            return;
            
        }

        private void DemoHash()
        {
            Console.WriteLine("\n**** Hash DEMO ***");

            var demo = new RedisHashOperations();

            /* add signle*/
            demo.AddHash("samples:hashTypeDemo:1", "a", "p");
            demo.AddHash("samples:hashTypeDemo:1", "b", "q");
            demo.AddHash("samples:hashTypeDemo:1", "c", "r");

            /* add multiple*/
            var inputs = new Dictionary<string, string>()
            {
                {"1","100"},
                {"2","200"},
                {"3","300"},
                {"4","400"},
                
            };
            demo.AddHash("samples:hashTypeDemo:2", inputs );

        }

        private void DemoSortedSet()
        {
            Console.WriteLine("\n**** OrderedSet DEMO ***");

            var demo = new RedisSortedSetOperations();

            /*add signle*/
            demo.Add("samples:sortedSetTypeDemo:1", "a", 100);
            demo.Add("samples:sortedSetTypeDemo:1", "b", 300);
            demo.Add("samples:sortedSetTypeDemo:1", "c", 200);
            demo.Add("samples:sortedSetTypeDemo:1", "d", 500);

            /* add multiple*/
            string[] inputs = new[]
            {
                "Hello",
                "Redis",
                "From",
                "Devcon"
            };
            demo.Add("samples:sortedSetTypeDemo:2", inputs);

        }

        private void DemoSet()
        {
            Console.WriteLine("\n**** SET DEMO ***");
            var setDemoIns = new RedisSetOperations();
            setDemoIns.AddSet("samples:setTypeDemo:1", "hello");
            setDemoIns.AddSet("samples:setTypeDemo:1", "redis");
            setDemoIns.AddSet("samples:setTypeDemo:1", "from");
            setDemoIns.AddSet("samples:setTypeDemo:1", "devcon");

            /*read all set values*/
            var setvalues= setDemoIns.ReadSet("samples:setTypeDemo:1");
            setvalues.ToList().ForEach(x=> Console.WriteLine(x));


            /*remvoe a value from set*/
            
            /*case sensitive key test*/
            Console.WriteLine(setDemoIns.RemoveAValueFromKey("samples:setTypeDemo:1", "Redis"));
            
            /*case sensitive key test*/
            Console.WriteLine(setDemoIns.RemoveAValueFromKey("samples:setTypeDemo:1", "redis"));

            /*remove same thing again*/
            Console.WriteLine(setDemoIns.RemoveAValueFromKey("samples:setTypeDemo:1", "redis"));

            /*check member exist*/
            Console.WriteLine(setDemoIns.IsMemebr("samples:setTypeDemo:1", "Devcon"));
            Console.WriteLine(setDemoIns.IsMemebr("samples:setTypeDemo:1", "devcon"));

            
        }

        private Task DemoList()
        {
            Console.WriteLine("\n**** LIST DEMO ***");
            var listDemoIns = new RedisListOperations();
            string[] inputs = new[]
            {
                "Hello",
                "Redis",
                "From",
                "Devcon"
            };

            /* add with lpush */
            listDemoIns.AddOneValueToList("samples:listTypeDemo:1", inputs[0]);
            listDemoIns.AddOneValueToList("samples:listTypeDemo:1", inputs[1]);
            listDemoIns.AddOneValueToList("samples:listTypeDemo:1", inputs[2]);
            listDemoIns.AddOneValueToList("samples:listTypeDemo:1", inputs[3]);

            /*read values*/
            //var listTopValue= listDemoIns.ReadoneValueFromTop("samples:listTypeDemo:1");
            //Console.WriteLine($"top value: {listTopValue}");
            //var listBottomvalValue= listDemoIns.ReadoneValueFromBottom("samples:listTypeDemo:1");
            //Console.WriteLine($"bottom value: {listBottomvalValue}");
            
            /*add list*/
            string[] extras = new[]
            {
                "1",
                "2",
                "3",
            };
            listDemoIns.AddValuesToTop("samples:listTypeDemo:2", extras);
            

            /* add to same key*/
            listDemoIns.AddValuesToTop("samples:listTypeDemo:1", extras);
            listDemoIns.AddValuesToBottom("samples:listTypeDemo:1", extras);

            return Task.CompletedTask;



        }

        private async Task DemoString()
        {
            Console.WriteLine("\n**** STRING DEMO ***");
            var stringDemoIns= new RedisStringOperations();
            await stringDemoIns.AddString("samples:stringTypeDemo:1", "Hello redis!");

            /*add more content*/
            await stringDemoIns.AddString("samples:stringTypeDemo:2", "How are you redis!");
            await stringDemoIns.AddString("samples:stringTypeDemo:2", "long time no see!");

            /* key case sensitivity */
            await stringDemoIns.AddString("Samples:stringTypeDemo:1", "hello redis!");


            /*Get key*/
            var valueFromRedis = await stringDemoIns.GetKey("samples:stringTypeDemo:1");
            Console.WriteLine(valueFromRedis);


            /*Delete key*/
            await stringDemoIns.DeleteKey("samples:stringTypeDemo:1");

            //stringDemoIns.CleanUp();

            return;
        }
    }
}
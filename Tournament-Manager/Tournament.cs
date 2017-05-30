using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tournament_Manager
{
    public enum Disc { Volleyball, RopeDragging, Dodgeball };
    public class Tournament
    {
        private Contest contestVolleyball;
        private Contest contestRopeDragging;
        private Contest contestDodgeball;
        public Tournament()
        {
            contestVolleyball = new Contest(Disc.Volleyball);
            contestRopeDragging = new Contest(Disc.RopeDragging);
            contestDodgeball = new Contest(Disc.Dodgeball);

        }

        public Contest ContestVolleyball
        {
            get { return contestVolleyball; }
        }
        public Contest ContestRopeDragging
        {
            get { return contestRopeDragging; }
        }
        public Contest ContestDodgeball
        {
            get { return contestDodgeball; }
        }
        public void saveState(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }
        public void loadState(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Deserialize(fs);
            fs.Close();
        }
    }
}

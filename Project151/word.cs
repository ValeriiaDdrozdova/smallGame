using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Project151
{

    public partial class Form1
    {
        string[] wordList =
        {
           "loss","tooth","height","pie","night","two","wife","chest","meal","youth","a","act","add",
            "year","way","cheek","mom","after","again","age","ago","agree","air","all","am","an","and",
            "angry","smell","crack","raise","crash","bid","clear","ask","ring","split","twist","mix","look",
            "face","add","train","wish","eat","debt","map","love","world","tale","soup","guest","bird",
            "sir","lab","week","bath","role","skill","news","town","gene","thing","meat","son","hair",
            "hat","exempt","steward","hobby","girlfriend","fence","shadow","resort","wriggle","duty",
            "sawow","aircraft","airline","airport","album","alcohol","career","certainly","announce",
            "annual","another","answer","anticipate","anxiety","channel","chapter","basketball","bathroom",
            "battery","device","devote","dialogue","effective","battle","squash","snake","rain","bank",
            "rubbish","snow","study","amber","watch","translate","drift","straight","cassette","golf",
            "grace","species","secure","pop","fax","earthwax","include","opposed","offense","post",
            "football","fuel","key","hunting","swing","theme","classroom","overflow","walleyed","underarm",
            "underdevelop","houseboat","foreman","foretold","underexpose","snakeskin","supercool",
            "turnbuckle","peppermint","grandmaster","slapstick","starfish","standout","earthworm",
            "taillight","civilization","cooperative","administration","characteristic","association",
            "constitutional","contemporary","intermediate","responsibility","enthusiasm","cooperation",
            "beneficiary","possibility","inappropriate","vegetarian","extraterrestrial","operational",
            "refrigerator","organisation","preoccupation","hospitality","multimedia","rehabilitation",
            "homosexual","investigation","discrimination","continuation","negotiation","qualification",
            "constituency","deteriorate","sensitivity","nationalism","communication","environmental",
            "examination","recommendation","supplementary","manufacturer","consideration","orientation",
            "accumulation","ambiguity","representative","disability","revolutionary","ideology",
            "identification","anniversary","liability","demonstration"
            };



        HashSet<String> usedWords = new HashSet<String>();

        Random r = new Random();

        string getRndWord(int complexity)
        {
            int index;
            if (complexity == 1) // simple
            {
                index = r.Next(0, 65);
            }
            else if (complexity == 2) // medium
            {
                index = r.Next(66, 131);
            }
            else                       // hard
                index = r.Next(132, 199);

            String result = wordList[index];

            if (usedWords.Count > 199)
            {
                usedWords.Clear();
            }

            if (usedWords.Contains(result))
            {
                return getRndWord(complexity);
            }

            usedWords.Add(result);
            return result;
        }

    }
}

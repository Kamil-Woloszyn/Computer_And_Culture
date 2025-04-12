using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public TMP_InputField countryInput;
    public GameObject factPanel;
    public TMP_Text factText;
    public Button submitButton;

    private Dictionary<string, string> countryFacts = new Dictionary<string, string>()
    {
        { "ireland", "Ireland is known as the Emerald Isle because it’s so green!" },
        { "france", "France is famous for the Eiffel Tower and yummy croissants!" },
        { "germany", "Germany has over 1,500 different kinds of sausages!" },
        { "italy", "Pizza and pasta come from Italy!" },
        { "spain", "In Spain, people sometimes take a nap in the afternoon called a 'siesta'." },
        { "japan", "Japan has trains so fast they’re called bullet trains!" },
        { "australia", "Australia has more kangaroos than people!" },
        { "canada", "Canada is so big it touches three oceans!" },
        { "brazil", "Brazil has the biggest rainforest in the world—the Amazon!" },
        { "egypt", "Egypt is home to the pyramids, built thousands of years ago!" },
        { "china", "The Great Wall of China is over 13,000 miles long!" },
        { "usa", "The USA has 50 states, and one is called Hawaii—it’s made of islands!" },
        { "india", "India has a big festival called Diwali, the festival of lights!" },
        { "south africa", "South Africa has 11 official languages!" },
        { "mexico", "Mexico is where tacos and piñatas come from!" },
        { "austria", "Austria is where classical music legends like Mozart were born!" },
        { "belgium", "Belgium is famous for making delicious chocolate and waffles." },
        { "denmark", "Denmark is often called the happiest country in the world!" },
        { "croatia", "Croatia has beautiful beaches and over 1,000 islands." },
        { "czech republic", "The Czech Republic has one of the oldest universities in Europe." },
        { "hungary", "Hungary’s capital, Budapest, has fun river cruises on the Danube." },
        { "pakistan", "Pakistan has some of the tallest mountains in the world." },
        { "nepal", "Mount Everest, the highest mountain in the world, is in Nepal!" },
        { "iran", "Iran has one of the oldest civilizations in the world." },
        { "iraq", "Iraq is where one of the first writing systems was created." },
        { "philippines", "The Philippines has over 7,000 islands!" },
        { "vietnam", "Vietnam is famous for its floating markets and tasty noodles!" },
        { "malaysia", "Malaysia has the world’s tallest twin towers—the Petronas Towers!" },
        { "singapore", "Singapore is a super clean city with a big airport waterfall!" },
        { "morocco", "Morocco has colorful markets and buildings with amazing patterns." },
        { "ethiopia", "Ethiopia has its own alphabet and never colonized by Europe." },
        { "tanzania", "Mount Kilimanjaro, the tallest mountain in Africa, is in Tanzania!" },
        { "colombia", "Colombia grows lots of the world’s coffee!" },
        { "chile", "Chile is the longest country in the world from top to bottom!" },
        { "venezuela", "Venezuela is home to Angel Falls, the tallest waterfall on Earth." },
        { "albania", "Albania has beaches along both the Adriatic and Ionian seas!" },
        { "armenia", "Armenia was the first country to make Christianity its official religion." },
        { "azerbaijan", "Azerbaijan has a city called 'The Land of Fire' where flames come from the ground!" },
        { "bangladesh", "Bangladesh has the largest river delta in the world." },
        { "bhutan", "Bhutan measures happiness instead of wealth—it has a Happiness Index!" },
        { "bolivia", "Bolivia has a salt desert so big, it looks like a giant mirror!" },
        { "bosnia and herzegovina", "Bosnia has a bridge that’s over 400 years old!" },
        { "botswana", "Botswana has huge elephant herds living in the wild." },
        { "bulgaria", "Bulgaria invented the Cyrillic alphabet, used in Russian too!" },
        { "cambodia", "Cambodia is home to Angkor Wat, the biggest religious monument in the world." },
        { "cameroon", "Cameroon is sometimes called 'Africa in miniature' because it has so many landscapes." },
        { "cape verde", "Cape Verde is a group of 10 volcanic islands in the Atlantic Ocean." },
        { "chad", "Lake Chad is one of the largest lakes in Africa." },
        { "congo", "The Congo River is one of the deepest rivers in the world." },
        { "costa rica", "Costa Rica has no army and is full of monkeys and volcanoes!" },
        { "cuba", "Cuba is known for its classic cars and colourful streets." },
        { "cyprus", "Cyprus is the birthplace of the goddess Aphrodite, in Greek mythology." },
        { "dominican republic", "The Dominican Republic shares an island with Haiti." },
        { "ecuador", "Ecuador is named after the equator—it runs right through it!" },
        { "el salvador", "El Salvador is the smallest country in Central America." },
        { "estonia", "Estonia loves technology—many government services are online!" },
        { "fiji", "Fiji is made up of over 300 tropical islands!" },
        { "georgia", "In Georgia, people use a unique alphabet that looks like curly script." },
        { "guatemala", "Guatemala has ancient Mayan pyramids hidden in the jungle." },
        { "haiti", "Haiti was the first independent Black republic in the world." },
        { "honduras", "Honduras has a rainforest called the 'Mosquito Coast'!" },
        { "jamaica", "Jamaica is the home of reggae music and Usain Bolt!" },
        { "jordan", "Jordan is home to Petra, a city carved into red rock cliffs." },
        { "kazakhstan", "Kazakhstan is the largest landlocked country in the world." },
        { "kosovo", "Kosovo is one of the youngest countries in the world—independent since 2008!" },
        { "kuwait", "Kuwait is one of the hottest countries on Earth!" },
        { "kyrgyzstan", "Kyrgyzstan has beautiful mountains and people who live in yurts." },
        { "laos", "Laos is one of the few countries in the world with no sea coast." },
        { "latvia", "Latvia is covered in forests—over half the country is green!" },
        { "lebanon", "Lebanon has ruins of Roman temples and ancient cities." },
        { "libya", "Most of Libya is covered by the Sahara Desert!" },
        { "liechtenstein", "Liechtenstein is so small, you can walk across it in a day!" },
        { "lithuania", "Lithuania was once part of the biggest country in Europe in the Middle Ages." },
        { "luxembourg", "Luxembourg is one of the richest countries in the world!" },
        { "malawi", "Malawi is called 'The Warm Heart of Africa' because of its kind people." },
        { "malta", "Malta has ancient stone temples older than the pyramids!" },
        { "moldova", "Moldova is known for its underground wine city!" },
        { "mongolia", "Mongolia has more horses than people!" },
        { "montenegro", "Montenegro means 'Black Mountain' in Italian." },
        { "myanmar", "In Myanmar, people wear a yellow paste called thanaka on their faces to keep cool." },
        { "namibia", "Namibia has giant red sand dunes and a spooky skeleton coast!" },
        { "nicaragua", "Nicaragua has both freshwater sharks and volcanoes!" },
        { "oman", "Oman has deserts, beaches, and mountains all in one country!" },
        { "panama", "The Panama Canal lets ships travel between the Atlantic and Pacific oceans." },
        { "paraguay", "Paraguay is one of the only countries where people speak an Indigenous language called Guaraní." },
        { "qatar", "Qatar will host the World Cup in stadiums with air conditioning!" },
        { "romania", "Romania has a castle linked to the Dracula legend—Spooky!" },
        { "russia", "Russia is the biggest country in the world!" },
        { "saudi arabia", "Saudi Arabia has the biggest sand desert on Earth!" },
        { "senegal", "Senegal is known for its colorful music and dancing." },
        { "serbia", "Serbia has a trumpet festival where everyone plays music in the streets!" },
        { "sierra leone", "Sierra Leone is known for its beautiful white-sand beaches." },
        { "slovakia", "Slovakia has over 6,000 caves and underground places to explore!" },
        { "slovenia", "Slovenia has a magical lake with a little island and a church on it." },
        { "solomon islands", "Solomon Islands are made up of hundreds of tropical islands!" },
        { "somalia", "Somalia’s coastline is longer than any other in mainland Africa." },
        { "sri lanka", "Sri Lanka is known for tea plantations and friendly elephants!" },
        { "sudan", "Sudan has more ancient pyramids than Egypt!" },
        { "suriname", "Suriname is the smallest country in South America." },
        { "syria", "Syria has some of the oldest cities in the world." },
        { "tajikistan", "Tajikistan is 93% mountains—nearly the whole country!" },
        { "timor-leste", "Timor-Leste is one of the youngest countries in the world." },
        { "togo", "Togo is a long and skinny country on Africa's west coast." },
        { "tunisia", "Parts of Star Wars were filmed in the deserts of Tunisia!" },
        { "turkmenistan", "Turkmenistan has a huge burning hole called the 'Door to Hell'!" },
        { "uganda", "Uganda is where you can see gorillas in the wild." },
        { "ukraine", "Ukraine has fields of sunflowers stretching for miles!" },
        { "united arab emirates", "The UAE has the tallest building in the world—Burj Khalifa!" },
        { "uruguay", "Uruguay was the first country to host the World Cup!" },
        { "uzbekistan", "Uzbekistan has ancient cities that were part of the Silk Road." },
        { "vanuatu", "Vanuatu is a group of islands where you can watch volcanoes safely." },
        { "vatican city", "Vatican City is the smallest country in the world!" },
        { "yemen", "Yemen has beautiful ancient buildings that look like gingerbread houses." },
        { "zambia", "Zambia shares Victoria Falls—one of the biggest waterfalls—with Zimbabwe." },
        { "zimbabwe", "Zimbabwe is named after Great Zimbabwe, a stone city built long ago." },
        { "andorra", "Andorra is a tiny country in the mountains between France and Spain." },
        { "antigua and barbuda", "This island nation has 365 beaches—one for every day of the year!" },
        { "bahamas", "The Bahamas has clear blue water perfect for swimming with dolphins!" },
        { "barbados", "Barbados is where pop singer Rihanna was born!" },
        { "brunei", "Brunei is a small country rich in oil and very green!" },
        { "burkina faso", "Burkina Faso means 'land of honest people.'" },
        { "central african republic", "This country is exactly in the center of Africa!" },
        { "comoros", "Comoros is a small island country near Madagascar with amazing coral reefs." },
        { "djibouti", "Djibouti has one of the saltiest lakes in the world—Lake Assal." },
        { "equatorial guinea", "Equatorial Guinea is the only African country that speaks Spanish." },
        { "eritrea", "Eritrea has colorful traditional clothes and tasty spicy food." },
        { "gabon", "Gabon is mostly rainforest and home to many gorillas!" },
        { "gambia", "The Gambia is the smallest country on mainland Africa." },
        { "grenada", "Grenada is called the Island of Spice because it grows so many spices!" },
        { "guinea", "Guinea has rivers that start in its mountains and flow all across West Africa." },
        { "guinea-bissau", "Guinea-Bissau has many small islands full of birds and monkeys." },
        { "lesotho", "Lesotho is the only country in the world that's completely above 1,000 meters in height!" },
        { "marshall islands", "The Marshall Islands are tiny atolls with glowing blue lagoons!" },
        { "micronesia", "Micronesia has ancient stone ruins on the island of Pohnpei." }
    };


    // Start is called before the first frame update
    void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
        factPanel.SetActive(false); // Hide panel at start
    }

    void OnSubmit()
    {
        
        string countryName = countryInput.text.ToLower().Trim();

        if (countryFacts.ContainsKey(countryName))
        {
            factText.text = countryFacts[countryName];
        }
        else
        {
            factText.text = $"No fact available for \"{countryName}\".";
        }

        factPanel.SetActive(true);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WordToGuess : MonoBehaviour
{
    public static WordToGuess Instance;
    public string word;

    public string[] possibleWords = {"Astronaut",
                                "Backpack",
                                "Banana Peel",
                                "Batman",
                                "Basketball",
                                "Beehive",
                                "Bubble Bath",
                                "Cactus",
                                "Castle",
                                "Caterpillar",
                                "Circus",
                                "Cupcake",
                                "Dinosaur",
                                "Disco",
                                "Dragon",
                                "Dragonfly",
                                "Eiffel Tower",
                                "Elephant",
                                "Fairy",
                                "Fireman",
                                "Fireworks",
                                "Ghost",
                                "Giraffe",
                                "Guitar",
                                "Hippo",
                                "Hot Air Balloon",
                                "Hula Hoop",
                                "Ice Cream",
                                "Jack-in-the-box",
                                "Jellyfish",
                                "Jigsaw Puzzle",
                                "Juggling",
                                "Kangaroo",
                                "Karaoke",
                                "Karate",
                                "Kite",
                                "Koala",
                                "Lawn Mower",
                                "Lightning",
                                "Mermaid",
                                "Microwave",
                                "Milkshake",
                                "Monkey",
                                "Microwave",
                                "Ostrich",
                                "Pajamas",
                                "Parrot",
                                "Pegasus",
                                "Pizza",
                                "Pirate",
                                "Plumber",
                                "Popcorn",
                                "Pretzel",
                                "Rodeo",
                                "Rock Climbing",
                                "Rollercoaster",
                                "Robot",
                                "Scooter",
                                "Scarecrow",
                                "Sherlock Holmes",
                                "Skateboarding",
                                "Snow Globe",
                                "Snowboarding",
                                "Snowman",
                                "Soccer",
                                "Space Shuttle",
                                "Spider",
                                "Statue of Liberty",
                                "Stethoscope",
                                "Submarine",
                                "Sushi",
                                "Surfing",
                                "Tambourine",
                                "Tarzan",
                                "Thunderstorm",
                                "Time Machine",
                                "Tornado",
                                "Toothbrush",
                                "Tug of War",
                                "UFO",
                                "Unicorn",
                                "Vampire",
                                "Windmill",
                                "Witch",
                                "Yoga",
                                "Zebra",
                                "Zipline"
    };

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}

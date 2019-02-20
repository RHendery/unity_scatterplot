

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewBehaviourScript : MonoBehaviour
{
    public struct DataPoint
    {
        public float x;
        public float y;
        public float z;
        public string label;
        public string family;
        public string region; //add this back in later for colour
    }



    public GameObject sphere;
    public GameObject sphere_blue;
    public GameObject sphere_green;
    public GameObject sphere_orange;
    public GameObject sphere_cyan;
    public GameObject sphere_purple;
    public Object newPrefab;

    // Use this for initialization
    void Start()
    {
        List<DataPoint> scatterPoints = readCSVfile();



        for (int index = 0; index < scatterPoints.Count; index++)
        {

            float one = (scatterPoints[index].x - 0.5f) * 5;
            float two = (scatterPoints[index].y - 0.5f) * 5;
            float three = (scatterPoints[index].z - 0.5f) * 5;


            // newPrefab = Instantiate(sphere_blue, new Vector3(one, two, three), Quaternion.identity);


            if (scatterPoints[index].family == "Pama-Nyungan")
            {
                newPrefab = Instantiate(sphere, new Vector3(one, two, three), Quaternion.identity);
            }

            if (scatterPoints[index].family == "Indo-European") newPrefab = Instantiate(sphere_blue, new Vector3(one, two, three), Quaternion.identity);
            if (scatterPoints[index].family == "Tibeto-Burman") newPrefab = Instantiate(sphere_green, new Vector3(one, two, three), Quaternion.identity);
            if (scatterPoints[index].family == "Oceanic") newPrefab = Instantiate(sphere_cyan, new Vector3(one, two, three), Quaternion.identity);
            if (scatterPoints[index].family == "Trans New Guinea") newPrefab = Instantiate(sphere_orange, new Vector3(one, two, three), Quaternion.identity);
            if (scatterPoints[index].family == "Afro-Asiatic") newPrefab = Instantiate(sphere_purple, new Vector3(one, two, three), Quaternion.identity);


            newPrefab.name = scatterPoints[index].label;
            /*
                        Color myColor = new Color();
                        ColorUtility.TryParseHtmlString(scatterPoints[index].region, out myColor);
                        Debug.Log(myColor);

                        Renderer rend = sphere_blue.GetComponent<Renderer>();

                        rend.material.SetColor("_TintColor", myColor);

                        //    MeshRenderer myrenderer = newPrefab.GetComponent<Renderer>();

                        //    sphere_blue.GetComponent<myrenderer>().material.SetColor("_TintColor", Color.green);
                        */

        }




    }

    // Update is called once per frame
    void Update()
    {

    }


    List<DataPoint> readCSVfile()
    {

        System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\DHRG\Desktop\all-VR.csv");

        string sLine;
        List<DataPoint> aDataPoints = new List<DataPoint>();

        // First line in the file is not useful so skip over it
        sLine = file.ReadLine();

        while ((sLine = file.ReadLine()) != null)
        //    while (std::getline(infile, sLine))
        {
            DataPoint tempDataPoint;
            string[] fields = sLine.Split(',');

            tempDataPoint.x = float.Parse(fields[0]);
            tempDataPoint.y = float.Parse(fields[1]);
            tempDataPoint.z = float.Parse(fields[2]);
            tempDataPoint.label = fields[3];
            tempDataPoint.family = fields[4];
            tempDataPoint.region = fields[5];

            aDataPoints.Add(tempDataPoint);

        }
        file.Close();

        return aDataPoints;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
using System.Globalization;
using System.Text;
using System.Linq;

public class Json_Controller : MonoBehaviour
{
    public Root root;
    public Root2 root2;
    public OBJ_XZ obj_xz_item;
    public MAT_LIST mat_root;
    GameObject Player_Hero;

    string aid_val;
    List<int> equipment_val;
    string charId;
    string Recept_ptogress = "";
    //Vector3[] Quest_vector;

    List<Vector3> vectors = new List<Vector3>();
    List<int> names = new List<int>();
    List<string> name_obj_mat = new List<string>();
    List<Material> materials = new List<Material>();

    VALUE val;


    public void load_obj_xz(Vector3 Player_data)
    {
        //obj_xz_item = JsonUtility.FromJson<OBJ_XZ>(jsdata);
        //Player_data = (float)Math.Round(Player_data, 2);      
        List<int> Obj = new List<int>();

        for (int i = 0; i < names.Count; i++)
        {
            var dist = Vector3.Distance(vectors[i], Player_data);
            //Debug.Log(Canvas_Game.GetComponent<VALUE>().scroll_vector.sqrMagnitude - Zero.sqrMagnitude);
            //Debug.Log(obj_xz_item.name[i] + " = " + dist);

            if (dist < 80f)
            {
                Obj.Add(i);

                Debug.Log(obj_xz_item.name[i]);
            }
        }
        gameObject.GetComponent<Load_Bundle>().Obj_List = Obj;
        //gameObject.GetComponent<Load_Bundle>().reload_bandle(0);

    }

    public IEnumerator Dinamic_Load_OBJ(Vector3 vector_player)
    {
        string test = "{\"vector\":[{\"x\":1155.8199462890625,\"y\":-0.8899999856948853,\"z\":-625.739990234375},{\"x\":1140.780029296875,\"y\":-0.3700000047683716,\"z\":-625.739990234375},{\"x\":1140.780029296875,\"y\":-0.15000000596046449,\"z\":-636.0999755859375},{\"x\":1120.199951171875,\"y\":11.449999809265137,\"z\":-656.8399658203125},{\"x\":1120.199951171875,\"y\":2.9200000762939455,\"z\":-647.0999755859375},{\"x\":1140.780029296875,\"y\":0.800000011920929,\"z\":-647.0999755859375},{\"x\":1140.780029296875,\"y\":4.760000228881836,\"z\":-657.4599609375},{\"x\":1155.8199462890625,\"y\":2.9000000953674318,\"z\":-591.3800048828125},{\"x\":1155.8199462890625,\"y\":-0.8999999761581421,\"z\":-581.6400146484375},{\"x\":1176.4000244140625,\"y\":-5.28000020980835,\"z\":-581.6400146484375},{\"x\":1176.4000244140625,\"y\":-2.440000057220459,\"z\":-592.0},{\"x\":1176.4000244140625,\"y\":1.399999976158142,\"z\":-625.739990234375},{\"x\":1155.8199462890625,\"y\":-1.100000023841858,\"z\":-612.739990234375},{\"x\":1155.8199462890625,\"y\":1.5,\"z\":-603.0},{\"x\":1176.4000244140625,\"y\":-0.18000000715255738,\"z\":-603.0},{\"x\":1176.4000244140625,\"y\":1.4500000476837159,\"z\":-613.3599853515625},{\"x\":1120.199951171875,\"y\":1.090000033378601,\"z\":-591.3800048828125},{\"x\":1120.199951171875,\"y\":-0.5,\"z\":-581.6400146484375},{\"x\":1140.780029296875,\"y\":1.2999999523162842,\"z\":-581.6400146484375},{\"x\":1140.780029296875,\"y\":3.9100000858306886,\"z\":-592.0},{\"x\":1120.199951171875,\"y\":1.5,\"z\":-612.739990234375},{\"x\":1120.199951171875,\"y\":3.299999952316284,\"z\":-603.0},{\"x\":1176.4000244140625,\"y\":2.200000047683716,\"z\":-636.0999755859375},{\"x\":1140.780029296875,\"y\":3.4000000953674318,\"z\":-603.0},{\"x\":1140.780029296875,\"y\":1.3600001335144044,\"z\":-613.3599853515625},{\"x\":1098.800048828125,\"y\":3.9000000953674318,\"z\":-613.3599853515625},{\"x\":1098.800048828125,\"y\":2.0399999618530275,\"z\":-593.5999755859375},{\"x\":1098.800048828125,\"y\":-4.300000190734863,\"z\":-578.5},{\"x\":1098.800048828125,\"y\":6.300000190734863,\"z\":-630.4000244140625},{\"x\":1195.300048828125,\"y\":-2.799999952316284,\"z\":-581.6400146484375},{\"x\":1195.300048828125,\"y\":1.5,\"z\":-596.8099975585938},{\"x\":1195.300048828125,\"y\":7.699999809265137,\"z\":-614.9000244140625},{\"x\":1195.300048828125,\"y\":12.699999809265137,\"z\":-633.2000122070313},{\"x\":1155.8199462890625,\"y\":2.7799999713897707,\"z\":-656.8399658203125},{\"x\":1195.300048828125,\"y\":-8.0,\"z\":-559.9000244140625},{\"x\":1195.300048828125,\"y\":-12.800000190734864,\"z\":-534.2999877929688},{\"x\":1195.300048828125,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1161.5,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1127.800048828125,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1098.800048828125,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1161.5,\"y\":-14.199999809265137,\"z\":-527.5},{\"x\":1127.800048828125,\"y\":-14.199999809265137,\"z\":-527.5},{\"x\":1098.800048828125,\"y\":-14.199999809265137,\"z\":-527.5},{\"x\":1195.300048828125,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1155.8199462890625,\"y\":0.20000000298023225,\"z\":-647.0999755859375},{\"x\":1161.5,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1127.800048828125,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1098.800048828125,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1195.300048828125,\"y\":-16.450000762939454,\"z\":-439.8399963378906},{\"x\":1161.5,\"y\":-16.530000686645509,\"z\":-439.8399963378906},{\"x\":1127.800048828125,\"y\":-17.459999084472658,\"z\":-439.8399963378906},{\"x\":1098.800048828125,\"y\":-18.729999542236329,\"z\":-439.8399963378906},{\"x\":1294.7999267578125,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1261.0999755859375,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1232.0999755859375,\"y\":-15.460000038146973,\"z\":-502.6000061035156},{\"x\":1176.4000244140625,\"y\":3.0,\"z\":-647.0999755859375},{\"x\":1294.7999267578125,\"y\":-14.199999809265137,\"z\":-527.5},{\"x\":1261.0999755859375,\"y\":-14.199999809265137,\"z\":-527.5},{\"x\":1232.0999755859375,\"y\":-13.0,\"z\":-527.5},{\"x\":1328.5999755859375,\"y\":-12.5600004196167,\"z\":-475.1000061035156},{\"x\":1294.7999267578125,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1261.0999755859375,\"y\":-16.100000381469728,\"z\":-475.1000061035156},{\"x\":1232.0999755859375,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1328.5999755859375,\"y\":-6.599999904632568,\"z\":-439.8399963378906},{\"x\":1294.7999267578125,\"y\":-10.4399995803833,\"z\":-439.8399963378906},{\"x\":1261.0999755859375,\"y\":-13.09000015258789,\"z\":-439.8399963378906},{\"x\":1176.4000244140625,\"y\":3.8000001907348635,\"z\":-657.4599609375},{\"x\":1232.0999755859375,\"y\":-14.710000038146973,\"z\":-439.8399963378906},{\"x\":1061.300048828125,\"y\":-18.100000381469728,\"z\":-534.2999877929688},{\"x\":1061.300048828125,\"y\":-20.09000015258789,\"z\":-502.6000061035156},{\"x\":1027.5,\"y\":-21.100000381469728,\"z\":-502.6000061035156},{\"x\":993.800048828125,\"y\":-21.100000381469728,\"z\":-502.6000061035156},{\"x\":964.800048828125,\"y\":-21.100000381469728,\"z\":-502.6000061035156},{\"x\":1027.5,\"y\":-21.729999542236329,\"z\":-527.5},{\"x\":993.800048828125,\"y\":-22.639999389648439,\"z\":-527.5},{\"x\":964.800048828125,\"y\":-22.530000686645509,\"z\":-527.5},{\"x\":1061.300048828125,\"y\":-20.15999984741211,\"z\":-475.1000061035156},{\"x\":1120.199951171875,\"y\":0.7900000214576721,\"z\":-635.47998046875},{\"x\":1027.5,\"y\":-21.100000381469728,\"z\":-475.1000061035156},{\"x\":993.800048828125,\"y\":-21.100000381469728,\"z\":-475.1000061035156},{\"x\":964.800048828125,\"y\":-21.100000381469728,\"z\":-475.1000061035156},{\"x\":1061.300048828125,\"y\":-20.15999984741211,\"z\":-439.8399963378906},{\"x\":1027.5,\"y\":-21.100000381469728,\"z\":-439.8399963378906},{\"x\":993.800048828125,\"y\":-21.100000381469728,\"z\":-439.8399963378906},{\"x\":964.800048828125,\"y\":-21.100000381469728,\"z\":-439.8399963378906},{\"x\":1120.199951171875,\"y\":1.4900000095367432,\"z\":-625.739990234375},{\"x\":1155.8199462890625,\"y\":-0.8899999856948853,\"z\":-635.47998046875}],\"name\":[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86]}";
        obj_xz_item = JsonUtility.FromJson<OBJ_XZ>(test);
        var vec = obj_xz_item.vector;
        var name = obj_xz_item.name;
        List<int> Obj_name = new List<int>();

        for (int i = 0; i < vec.Count; i++)
        {
            var dist = Vector3.Distance(vec[i], vector_player);
            if (dist < 15)
            {
                Obj_name.Add(name[i]);
                //Debug.Log(name[i]);
            }
        }
        gameObject.GetComponent<Load_Bundle>().Obj_List = Obj_name;
        StartCoroutine(gameObject.GetComponent<Load_Bundle>().Load_Bundle_func());
        //Debug.Log(Obj_name.Count);
        yield return null;
    }

    public void Save_Material(List<string> name, List<string> List_mat)
    {
        mat_root.list.Clear();
        mat_root.materials.Clear();
        for (int i = 0; i < name.Count; i++)
        {
            mat_root.list.Add(name[i]);
            //mat_root.materials.Add(List_mat[i]);
            mat_root.materials.Add(List_mat[i]);
        }
        File.WriteAllText(Application.streamingAssetsPath + "/JSON_mat.json", JsonUtility.ToJson(mat_root));
    }
    public void Load_Material()
    {
        //string read_file = File.ReadAllText(Application.streamingAssetsPath + "/JSON_mat.json");// для теста
        string read_file = "{\"list\":[\"DF_C_Big_Bridge_1 (1)\",\"DF_C_Big_Bridge_1\",\"DF_C_Big_Bridge_2\",\"DF_C_Big_Bridge_3_1\",\"DF_C_Big_Bridge_3_2\",\"DF_C_Big_Bridge_3_3\",\"DF_C_Bridge_1_Border\",\"DF_C_Bridge_1_Brick_Floor\",\"DF_C_Bridge_1_Brick_Under_Floor\",\"DF_C_Bridge_1_Wall\",\"DF_C_Bridge_Section_1_1_Border\",\"DF_C_Bridge_Section_1_1_Wall\",\"DF_C_Bridge_Section_1_2_Border\",\"DF_C_Bridge_Section_1_2_Wall\",\"DF_C_Bridge_Section_2_Border\",\"DF_C_Bridge_Section_2_Wall\",\"DF_C_Bridge_Section_3_Border\",\"DF_C_Bridge_Section_3_Wall\",\"DF_C_Cental_Inside_Border\",\"DF_C_Cental_Inside_Wall\",\"DF_C_Central_Section_Border_1\",\"DF_C_Central_Section_Border_2\",\"DF_C_Central_Section_Door_1\",\"DF_C_Central_Section_Door_1_1\",\"DF_C_Central_Section_Door_1_2\",\"DF_C_Central_Section_Door_1_2_2\",\"DF_C_Central_Section_Door_2_1\",\"DF_C_Central_Section_Door_2_2\",\"DF_C_Central_Section_Door_3_1\",\"DF_C_Central_Section_Door_3_2\",\"DF_C_Central_Section_Inside_1_low\",\"DF_C_Central_Section_Inside_2_low\",\"DF_C_Central_Section_Wall_1\",\"DF_C_Central_Section_Wall_2\",\"DF_C_Central_Section_Wall_3\",\"DF_C_Central_Section_Wall_4\",\"DF_C_Enter_Group_Element_1_1\",\"DF_C_Enter_Group_Element_1_2\",\"DF_C_Enter_Group_Element_2_1\",\"DF_C_Enter_Group_Element_2_2\",\"DF_C_Enter_Group_Element_3_1\",\"DF_C_Enter_Group_Element_3_2\",\"DF_C_Enter_Group_Element_3_3\",\"DF_C_Floor_1\",\"DF_C_Floor_2\",\"DF_C_Floor_3\",\"DF_C_Floor_4\",\"DF_C_Floor_5\",\"DF_C_Floor_6\",\"DF_C_Floor_7\",\"DF_C_Floor_Border\",\"DF_C_Lava_Floor\",\"DF_C_Mountain\",\"DF_C_Outdoor\",\"DF_C_Pile_of_Snow (1)\",\"DF_C_Pile_of_Snow (10)\",\"DF_C_Pile_of_Snow (11)\",\"DF_C_Pile_of_Snow (12)\",\"DF_C_Pile_of_Snow (13)\",\"DF_C_Pile_of_Snow (14)\",\"DF_C_Pile_of_Snow (15)\",\"DF_C_Pile_of_Snow (16)\",\"DF_C_Pile_of_Snow (17)\",\"DF_C_Pile_of_Snow (18)\",\"DF_C_Pile_of_Snow (19)\",\"DF_C_Pile_of_Snow (2)\",\"DF_C_Pile_of_Snow (20)\",\"DF_C_Pile_of_Snow (21)\",\"DF_C_Pile_of_Snow (22)\",\"DF_C_Pile_of_Snow (23)\",\"DF_C_Pile_of_Snow (24)\",\"DF_C_Pile_of_Snow (25)\",\"DF_C_Pile_of_Snow (26)\",\"DF_C_Pile_of_Snow (27)\",\"DF_C_Pile_of_Snow (28)\",\"DF_C_Pile_of_Snow (29)\",\"DF_C_Pile_of_Snow (3)\",\"DF_C_Pile_of_Snow (30)\",\"DF_C_Pile_of_Snow (31)\",\"DF_C_Pile_of_Snow (32)\",\"DF_C_Pile_of_Snow (33)\",\"DF_C_Pile_of_Snow (34)\",\"DF_C_Pile_of_Snow (35)\",\"DF_C_Pile_of_Snow (36)\",\"DF_C_Pile_of_Snow (37)\",\"DF_C_Pile_of_Snow (38)\",\"DF_C_Pile_of_Snow (39)\",\"DF_C_Pile_of_Snow (4)\",\"DF_C_Pile_of_Snow (40)\",\"DF_C_Pile_of_Snow (41)\",\"DF_C_Pile_of_Snow (42)\",\"DF_C_Pile_of_Snow (43)\",\"DF_C_Pile_of_Snow (44)\",\"DF_C_Pile_of_Snow (45)\",\"DF_C_Pile_of_Snow (46)\",\"DF_C_Pile_of_Snow (47)\",\"DF_C_Pile_of_Snow (48)\",\"DF_C_Pile_of_Snow (49)\",\"DF_C_Pile_of_Snow (5)\",\"DF_C_Pile_of_Snow (50)\",\"DF_C_Pile_of_Snow (51)\",\"DF_C_Pile_of_Snow (52)\",\"DF_C_Pile_of_Snow (53)\",\"DF_C_Pile_of_Snow (54)\",\"DF_C_Pile_of_Snow (55)\",\"DF_C_Pile_of_Snow (56)\",\"DF_C_Pile_of_Snow (57)\",\"DF_C_Pile_of_Snow (58)\",\"DF_C_Pile_of_Snow (59)\",\"DF_C_Pile_of_Snow (6)\",\"DF_C_Pile_of_Snow (60)\",\"DF_C_Pile_of_Snow (61)\",\"DF_C_Pile_of_Snow (7)\",\"DF_C_Pile_of_Snow (8)\",\"DF_C_Pile_of_Snow (9)\",\"DF_C_Rock_1 (10)\",\"DF_C_Rock_1 (11)\",\"DF_C_Rock_1 (12)\",\"DF_C_Rock_1 (13)\",\"DF_C_Rock_1 (14)\",\"DF_C_Rock_1 (15)\",\"DF_C_Rock_1 (16)\",\"DF_C_Rock_1 (17)\",\"DF_C_Rock_1 (4)\",\"DF_C_Rock_1 (5)\",\"DF_C_Rock_1 (6)\",\"DF_C_Rock_1 (7)\",\"DF_C_Rock_1 (8)\",\"DF_C_Rock_1 (9)\",\"DF_C_Rock_2 (1)\",\"DF_C_Rock_2 (2)\",\"DF_C_Rock_2 (3)\",\"DF_C_Rock_2\",\"DF_C_Section_1_Border_1\",\"DF_C_Section_1_Border_2\",\"DF_C_Section_1_Wall_1\",\"DF_C_Section_1_Wall_2\",\"DF_C_Section_1_Wall_3\",\"DF_C_Section_2_Border_1\",\"DF_C_Section_2_Border_2\",\"DF_C_Section_2_Wall_1\",\"DF_C_Section_2_Wall_2\",\"DF_C_Section_2_Wall_3\",\"DF_C_Section_3_Border_1\",\"DF_C_Section_3_Border_2\",\"DF_C_Section_3_Wall_1\",\"DF_C_Section_3_Wall_2\",\"DF_C_Section_3_Wall_3\",\"DF_C_Stair_Border\",\"DF_C_Stair_Bridge_Brick_Floor\",\"DF_C_Stair_Bridge_Brick_Under_Floor\",\"DF_C_Stair_Wall\",\"DF_C_Stair_Wall_2\",\"DF_C_Tile_model_floor_1_1\",\"DF_C_Tile_model_floor_1_1_Instance\",\"DF_C_Tile_model_floor_1_1_Instance_10\",\"DF_C_Tile_model_floor_1_1_Instance_11\",\"DF_C_Tile_model_floor_1_1_Instance_12\",\"DF_C_Tile_model_floor_1_1_Instance_13\",\"DF_C_Tile_model_floor_1_1_Instance_2\",\"DF_C_Tile_model_floor_1_1_Instance_3\",\"DF_C_Tile_model_floor_1_1_Instance_4\",\"DF_C_Tile_model_floor_1_1_Instance_5\",\"DF_C_Tile_model_floor_1_1_Instance_6\",\"DF_C_Tile_model_floor_1_1_Instance_7\",\"DF_C_Tile_model_floor_1_1_Instance_8\",\"DF_C_Tile_model_floor_1_1_Instance_9\",\"DF_C_Tile_Stair_Bridge_Border\",\"DF_C_Tile_Stair_Bridge_Wall\",\"DF_C_Trim_model_borders_set_1_5\",\"DF_C_Trim_model_borders_set_1_5_Instance\",\"DF_C_Trim_model_borders_set_1_5_Instance_10\",\"DF_C_Trim_model_borders_set_1_5_Instance_11\",\"DF_C_Trim_model_borders_set_1_5_Instance_12\",\"DF_C_Trim_model_borders_set_1_5_Instance_13\",\"DF_C_Trim_model_borders_set_1_5_Instance_2\",\"DF_C_Trim_model_borders_set_1_5_Instance_3\",\"DF_C_Trim_model_borders_set_1_5_Instance_4\",\"DF_C_Trim_model_borders_set_1_5_Instance_5\",\"DF_C_Trim_model_borders_set_1_5_Instance_6\",\"DF_C_Trim_model_borders_set_1_5_Instance_7\",\"DF_C_Trim_model_borders_set_1_5_Instance_8\",\"DF_C_Trim_model_borders_set_1_5_Instance_9\",\"DF_C_Trim_steps_1\",\"DF_C_Trim_steps_2\",\"DF_C_Trim_steps_3\",\"DF_C_Tunnel_Floor_L\",\"DF_C_Tunnel_Floor_R\",\"DF_C_Tunnel_L\",\"DF_C_Tunnel_R\",\"DF_C_Vertical_1\",\"DF_C_Vertical_1_10\",\"DF_C_Vertical_1_11\",\"DF_C_Vertical_1_2\",\"DF_C_Vertical_1_3\",\"DF_C_Vertical_1_4\",\"DF_C_Vertical_1_5\",\"DF_C_Vertical_1_6\",\"DF_C_Vertical_1_7\",\"DF_C_Vertical_1_8\",\"DF_C_Vertical_1_9\",\"DF_C_Vertical_2\",\"DF_C_Vertical_2_10\",\"DF_C_Vertical_2_11\",\"DF_C_Vertical_2_2\",\"DF_C_Vertical_2_3\",\"DF_C_Vertical_2_4\",\"DF_C_Vertical_2_5\",\"DF_C_Vertical_2_6\",\"DF_C_Vertical_2_7\",\"DF_C_Vertical_2_8\",\"DF_C_Vertical_2_9\",\"DF_C_Wood_Support (1)\",\"DF_C_Wood_Support (10)\",\"DF_C_Wood_Support (11)\",\"DF_C_Wood_Support (12)\",\"DF_C_Wood_Support (13)\",\"DF_C_Wood_Support (14)\",\"DF_C_Wood_Support (2)\",\"DF_C_Wood_Support (3)\",\"DF_C_Wood_Support (4)\",\"DF_C_Wood_Support (5)\",\"DF_C_Wood_Support (6)\",\"DF_C_Wood_Support (7)\",\"DF_C_Wood_Support (8)\",\"DF_C_Wood_Support (9)\",\"DF_C_Wood_Support\",\"DF_C_Wood_Support_Element_1 (1)\",\"DF_C_Wood_Support_Element_1 (10)\",\"DF_C_Wood_Support_Element_1 (11)\",\"DF_C_Wood_Support_Element_1 (12)\",\"DF_C_Wood_Support_Element_1 (13)\",\"DF_C_Wood_Support_Element_1 (2)\",\"DF_C_Wood_Support_Element_1 (3)\",\"DF_C_Wood_Support_Element_1 (4)\",\"DF_C_Wood_Support_Element_1 (5)\",\"DF_C_Wood_Support_Element_1 (6)\",\"DF_C_Wood_Support_Element_1 (7)\",\"DF_C_Wood_Support_Element_1 (8)\",\"DF_C_Wood_Support_Element_1 (9)\",\"DF_C_Wood_Support_Element_1\"],\"materials\":[\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Central_Section_Inside_1\",\"M_DF_C_Central_Section_Inside_2\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Floor_2\",\"M_DF_C_Floor_2\",\"M_DF_C_Floor_2\",\"M_DF_C_Floor_2\",\"M_DF_C_Floor_2\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Lava_Floor\",\"M_DF_C_Mountain\",\"M_DF_C_Floor_Canyon\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Pile_of_Snow\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_1\",\"M_DF_C_Rock_2_Tunnel\",\"M_DF_C_Rock_2_Tunnel\",\"M_DF_C_Rock_2_Tunnel\",\"M_DF_C_Rock_2_Tunnel\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tunnel_Floor\",\"M_DF_C_Tunnel_Floor\",\"M_DF_C_Tunnel_Wall\",\"M_DF_C_Tunnel_Wall\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\",\"M_DF_C_Wood_Support\"]}";
        mat_root = JsonUtility.FromJson<MAT_LIST>(read_file);        
    }
    public void Save_obj_xz(Dictionary<int, Vector3> bandles_vector)
    {
        //obj_xz_item.XZ = new Dictionary<int, Vector3>(bandles_vector);
        //var entries = bandles_vector.Select(d =>string.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));

        Debug.Log(bandles_vector.Count);
        Debug.Log(bandles_vector[0]);
        Debug.Log(bandles_vector[1]);
        obj_xz_item.name.Clear();
        obj_xz_item.vector.Clear();
        for (int i = 0; i < bandles_vector.Count; i++)
        {
            obj_xz_item.name.Add(i);
            obj_xz_item.vector.Add(bandles_vector[i]);
        }

        string json = JsonUtility.ToJson(obj_xz_item);
        Debug.Log(json);
        File.WriteAllText(Application.streamingAssetsPath + "/JSON_obj.json", json);
    }
    public void Load_json(string jsonString)
    {
        //Debug.Log(root.quest.Count);
        root = JsonUtility.FromJson<Root>(jsonString);

        aid_val = root.aid;
        equipment_val = root.equipment;
        charId = root.charId;
        val.Player_Name = root.name;

        if (root.quest.Count > 0)
        {
            val.Dialog_count = root.quest[0].dialog_count;
            val.Step_quest = root.quest[0].questStep;
            val.scroll_caunt = root.quest[1].scroll;

            if (root.quest[1].vector.Length == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    val.scroll_vector[i] = new Vector3(0, 0, 0);
                }
            }
            else
            {
                val.scroll_vector = root.quest[1].vector;
            }

            if (root.quest[0].recipe == "true")
            {
                val.recipe = true;
                val.Quest_done = true;
            }
            if (root.quest[0].recipe == "false")
            {
                val.recipe = false;
                val.Quest_done = false;
            }
            if (root.quest[0].recipe.Substring(0, 4) == "http")
            {
                val.Shild = true;
                val.Quest_done = true;
            }
        }
        //val.Svitok();

    }
    public void Load_json_Attributes(string jsonString)
    {
        root2 = JsonUtility.FromJson<Root2>(jsonString);
        val.level = root2.level;
        val.strength = root2.strength;

        val.experience = root2.experience;// опыт
        val.level = root2.level; // уровень
        val.strength = root2.strength;// сила
        val.attack = root2.attack;// атака
        val.st_resist = root2.st_resist;
        val.hp_regen = root2.hp_regen;// регенерация
        val.dexterity = root2.dexterity;// ловкость
        val.attack_speed = root2.attack_speed;// скорость атаки
        val.evasion = root2.evasion;
        val.accuracy = root2.accuracy;
        val.intelligence = root2.intelligence;
        val.m_attack = root2.m_attack;
        val.mp_regen = root2.mp_regen;
        val.move_speed = root2.move_speed;
        val.initial_attack_speed = root2.initial_attack_speed;
        val.initial_evasion = root2.initial_evasion;
        val.initial_accuracy = root2.initial_accuracy;
        val.critical_chance = root2.critical_chance;
        val.spell_speed = root2.spell_speed;
        val.cooldown = root2.cooldown;
        val.defence = root2.defence;
        val.m_resist = root2.m_resist;
        val.set_bonus = root2.set_bonus;
}
    public void Save_json()
    {
        var F = CultureInfo.InvariantCulture;
        Vector3[] V2 = new Vector3[5];
        V2 = val.scroll_vector;

        root.name = val.Player_Name;
        root.equipment = equipment_val;
        root.charId = charId;
        root2.experience = val.experience;
        if (val.processing) Recept_ptogress = "processing";

        root.quest.Add(new Quest(val.Step_quest, val.Dialog_count, Recept_ptogress, val.scroll_caunt, val.scroll_vector));

        string Out_mess = "{\"aid\":\"" + root.aid + "\"," + "\"equipment\":[" + root.equipment[0] + "," + root.equipment[1] + "," + root.equipment[2] + "," + root.equipment[3] + "," + root.equipment[4] + "]," +
           "\"name\":\"" + root.name + "\"," + "\"quest\":[{\"" + "questStep\":" + val.Step_quest + "," + "\"dialog_count\":" + val.Dialog_count + "," + "\"recipe\":\"" + Recept_ptogress + "\"},{\"scroll\":" + val.scroll_caunt + ",\"vector\":[{\"x\":" + V2[0].x.ToString(F) + ",\"y\":" + V2[0].y.ToString(F) + ",\"z\":" + V2[0].z.ToString(F) + "},{\"x\":" + V2[1].x.ToString(F) + ",\"y\":" + V2[1].y.ToString(F) + ",\"z\":" + V2[1].z.ToString(F) + "}," +
           "{\"x\":" + V2[2].x.ToString(F) + ",\"y\":" + V2[2].y.ToString(F) + ",\"z\":" + V2[2].z.ToString(F) + "},{\"x\":" + V2[3].x.ToString(F) + ",\"y\":" + V2[3].y.ToString(F) + ",\"z\":" + V2[3].z.ToString(F) + "},{\"x\":" + V2[4].x.ToString(F) + ",\"y\":" + V2[4].y.ToString(F) + ",\"z\":" + V2[4].z.ToString(F) + "}]}],\"position\":\"" + root.position + "\",\"charId\":\"" + root.charId + "\"}";


        //gameObject.GetComponent<Base_React>().Go(Out_mess);

        //Debug.Log(Out_mess);
        ////Debug.Log(root.quest.Count);

        //File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", Out_mess);// для тестаJsonUtility.ToJson(root)

        //Debug.Log(Out_mess2);
    }
    public void Save_atribute()
    {
        root2.experience = val.experience;
        root2.level = val.level;
        root2.strength = val.strength;
        root2.attack = val.attack;
        root2.st_resist = val.st_resist;
        root2.hp_regen = val.hp_regen;
        root2.dexterity = val.dexterity;
        root2.attack_speed = val.attack_speed;
        root2.evasion = val.evasion;
        root2.accuracy = val.accuracy;
        root2.intelligence = val.intelligence;
        root2.m_attack = val.m_attack;
        root2.mp_regen = val.mp_regen;
        root2.move_speed = val.move_speed;
        root2.initial_attack_speed = val.initial_attack_speed;
        root2.initial_evasion = val.initial_evasion;
        root2.initial_accuracy = val.initial_accuracy;
        root2.critical_chance = val.critical_chance;
        root2.spell_speed = val.spell_speed;
        root2.cooldown = val.cooldown;
        root2.defence = val.defence;
        root2.m_resist = val.m_resist;
        root2.set_bonus = val.set_bonus;
        string json = JsonUtility.ToJson(root2);
        //File.WriteAllText(Application.streamingAssetsPath + "/JSON3.json", json);
        //GetComponent<Base_React>().Attributes(json);
    }

    private void Awake()
    {
        //Load_Material();
    }
    void Start()
    {
        val = new VALUE();
        val = GetComponent<VALUE>();
        Player_Hero = GameObject.Find("Hero Variant");// найти объект
        Vector3 vector_player = Player_Hero.transform.position;

        // StartCoroutine(Dinamic_Load_OBJ(vector_player));
        Load_Material();
        //StartCoroutine(Load_Material());

        //Save_json();
        //for (int i = 0; i < 80; i++)
        //{
        //    ban_vec.Add(i, Vector3.zero);
        //}
        //Save_obj_xz(ban_vec);

        //string read_file = File.ReadAllText(Application.streamingAssetsPath + "/JSON_STRENGTH.json");
        ////string read_file = "{\"vector\":[{\"x\":1248.0999755859375,\"y\":-20.5,\"z\":-516.5},{\"x\":1177.644287109375,\"y\":2.286299228668213,\"z\":-650.087646484375},{\"x\":1178.570068359375,\"y\":1.7299991846084595,\"z\":-642.8999633789063},{\"x\":1146.9210205078125,\"y\":7.089999198913574,\"z\":-675.58642578125},{\"x\":1134.050048828125,\"y\":3.8999991416931154,\"z\":-661.179931640625},{\"x\":1132.7630615234375,\"y\":3.8999991416931154,\"z\":-656.052978515625},{\"x\":1164.570068359375,\"y\":14.299999237060547,\"z\":-690.3799438476563},{\"x\":1203.260009765625,\"y\":0.5499992370605469,\"z\":-595.8899536132813},{\"x\":1155.3299560546875,\"y\":-1.1749999523162842,\"z\":-641.5800170898438},{\"x\":1203.260009765625,\"y\":0.5499992370605469,\"z\":-595.8899536132813},{\"x\":1155.3299560546875,\"y\":-1.1749999523162842,\"z\":-641.5800170898438},{\"x\":1203.260009765625,\"y\":0.5499992370605469,\"z\":-595.8899536132813},{\"x\":1203.260009765625,\"y\":0.5499992370605469,\"z\":-595.8899536132813},{\"x\":1203.260009765625,\"y\":0.5499992370605469,\"z\":-595.8899536132813},{\"x\":1154.8900146484375,\"y\":2.1899986267089845,\"z\":-619.47998046875},{\"x\":1404.1776123046875,\"y\":-41.44606399536133,\"z\":-770.3084106445313},{\"x\":1162.9599609375,\"y\":7.510005950927734,\"z\":-682.5199584960938},{\"x\":1162.9599609375,\"y\":7.510005950927734,\"z\":-682.5199584960938},{\"x\":1172.4100341796875,\"y\":0.5899925231933594,\"z\":-628.0099487304688},{\"x\":1169.489990234375,\"y\":2.479991912841797,\"z\":-658.5},{\"x\":1155.3299560546875,\"y\":-1.1749999523162842,\"z\":-641.5800170898438},{\"x\":1155.3299560546875,\"y\":-1.1749999523162842,\"z\":-641.5800170898438},{\"x\":1135.6700439453125,\"y\":-0.09484565258026123,\"z\":-635.7239990234375},{\"x\":1203.260009765625,\"y\":0.5499992370605469,\"z\":-595.8899536132813},{\"x\":1203.260009765625,\"y\":0.5499992370605469,\"z\":-595.8899536132813},{\"x\":1155.3299560546875,\"y\":-1.1749999523162842,\"z\":-641.5800170898438},{\"x\":1155.3299560546875,\"y\":-1.1749999523162842,\"z\":-641.5800170898438},{\"x\":1213.449951171875,\"y\":16.8700008392334,\"z\":-657.0900268554688},{\"x\":1198.13037109375,\"y\":6.40000057220459,\"z\":-621.4099731445313},{\"x\":1230.0699462890625,\"y\":6.280000686645508,\"z\":-634.780029296875},{\"x\":1151.5550537109375,\"y\":8.759367942810059,\"z\":-647.5806274414063},{\"x\":1151.5550537109375,\"y\":8.759367942810059,\"z\":-647.5806274414063},{\"x\":1151.5550537109375,\"y\":8.759367942810059,\"z\":-647.5806274414063},{\"x\":1141.1900634765625,\"y\":-0.1420001983642578,\"z\":-644.8099365234375},{\"x\":1173.3499755859375,\"y\":2.8199996948242189,\"z\":-656.3399658203125},{\"x\":1162.1400146484375,\"y\":3.0099992752075197,\"z\":-662.719970703125},{\"x\":1136.844970703125,\"y\":0.06399917602539063,\"z\":-644.9529418945313},{\"x\":1203.260009765625,\"y\":0.5499992370605469,\"z\":-595.8899536132813},{\"x\":1154.2449951171875,\"y\":-0.1850000023841858,\"z\":-641.0659790039063},{\"x\":1155.3299560546875,\"y\":-1.1749999523162842,\"z\":-641.5800170898438},{\"x\":1203.260009765625,\"y\":0.5499992370605469,\"z\":-595.8899536132813},{\"x\":1127.4400634765625,\"y\":-0.1400008201599121,\"z\":-633.6599731445313},{\"x\":1127.0,\"y\":-0.1400008201599121,\"z\":-642.6399536132813},{\"x\":1127.4141845703125,\"y\":-0.12999343872070313,\"z\":-633.6624145507813},{\"x\":1127.0284423828125,\"y\":-0.12999343872070313,\"z\":-642.6541748046875},{\"x\":1127.42578125,\"y\":-0.11800003051757813,\"z\":-633.6482543945313},{\"x\":1127.0400390625,\"y\":-0.11800003051757813,\"z\":-642.6399536132813},{\"x\":1127.3990478515625,\"y\":-0.13512039184570313,\"z\":-633.6809692382813},{\"x\":1127.01318359375,\"y\":-0.13512039184570313,\"z\":-642.6727294921875},{\"x\":1164.05322265625,\"y\":-4.7848591804504398,\"z\":-116.85704040527344},{\"x\":1164.7191162109375,\"y\":-2.3752691745758058,\"z\":-117.4611587524414},{\"x\":1163.3800048828125,\"y\":-2.286536455154419,\"z\":-115.8699951171875},{\"x\":1163.6844482421875,\"y\":-3.302886486053467,\"z\":-116.52281188964844},{\"x\":1163.7694091796875,\"y\":-2.686367988586426,\"z\":-116.43669128417969},{\"x\":1162.82958984375,\"y\":-4.315799236297607,\"z\":-117.31256103515625},{\"x\":1163.8524169921875,\"y\":-2.720837354660034,\"z\":-116.36384582519531},{\"x\":1163.6976318359375,\"y\":-2.9784297943115236,\"z\":-116.51563262939453},{\"x\":1163.7313232421875,\"y\":-1.4882559776306153,\"z\":-116.48282623291016},{\"x\":1163.6634521484375,\"y\":-3.624817371368408,\"z\":-116.57781219482422},{\"x\":1136.444091796875,\"y\":0.4090000092983246,\"z\":-632.4080200195313},{\"x\":-153.800048828125,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":-153.800048828125,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":-153.800048828125,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":-153.800048828125,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":-153.800048828125,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":-153.800048828125,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":-153.800048828125,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":-153.800048828125,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":-153.800048828125,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":-153.800048828125,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":-353.800048828125,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":-353.800048828125,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":-353.800048828125,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":-353.800048828125,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":-353.800048828125,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":-353.800048828125,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":-353.800048828125,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":-353.800048828125,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":-353.800048828125,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":-553.800048828125,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":-553.800048828125,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":-553.800048828125,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":-553.800048828125,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":-553.800048828125,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":-553.800048828125,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":-553.800048828125,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":-553.800048828125,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":-553.800048828125,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":-553.800048828125,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":-753.800048828125,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":-753.800048828125,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":-753.800048828125,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":-753.800048828125,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":-753.800048828125,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":-753.800048828125,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":-753.800048828125,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":-753.800048828125,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":-753.800048828125,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":-753.800048828125,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":-953.7999267578125,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":-953.7999267578125,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":-953.7999267578125,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":-953.7999267578125,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":-953.7999267578125,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":-953.7999267578125,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":-953.7999267578125,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":-953.7999267578125,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":-953.7999267578125,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":-953.7999267578125,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":1046.199951171875,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":1046.199951171875,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":1046.199951171875,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":1046.199951171875,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":1046.199951171875,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":1046.199951171875,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":1046.199951171875,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":1046.199951171875,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":1046.199951171875,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":1246.199951171875,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":1246.199951171875,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":1246.199951171875,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":1246.199951171875,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":1246.199951171875,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":1246.199951171875,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":1246.199951171875,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":1246.199951171875,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":1246.199951171875,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":1246.199951171875,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":1446.199951171875,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":1446.199951171875,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":1446.199951171875,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":1446.199951171875,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":1446.199951171875,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":1446.199951171875,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":1446.199951171875,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":1446.199951171875,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":1446.199951171875,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":1446.199951171875,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":1646.199951171875,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":1646.199951171875,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":1646.199951171875,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":1646.199951171875,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":1646.199951171875,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":1646.199951171875,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":1646.199951171875,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":1646.199951171875,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":1646.199951171875,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":1646.199951171875,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":1846.199951171875,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":1846.199951171875,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":1846.199951171875,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":1846.199951171875,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":1846.199951171875,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":1846.199951171875,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":1846.199951171875,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":1846.199951171875,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":1846.199951171875,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":1846.199951171875,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":2046.199951171875,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":2046.199951171875,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":2046.199951171875,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":2046.199951171875,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":2046.199951171875,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":2046.199951171875,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":2046.199951171875,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":2046.199951171875,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":2046.199951171875,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":2046.199951171875,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":246.199951171875,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":246.199951171875,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":246.199951171875,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":246.199951171875,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":246.199951171875,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":246.199951171875,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":246.199951171875,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":246.199951171875,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":246.199951171875,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":246.199951171875,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":446.199951171875,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":446.199951171875,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":446.199951171875,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":446.199951171875,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":446.199951171875,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":446.199951171875,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":446.199951171875,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":446.199951171875,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":446.199951171875,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":446.199951171875,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":46.199951171875,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":46.199951171875,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":46.199951171875,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":46.199951171875,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":46.199951171875,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":46.199951171875,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":46.199951171875,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":46.199951171875,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":46.199951171875,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":46.199951171875,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":646.199951171875,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":646.199951171875,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":646.199951171875,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":646.199951171875,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":646.199951171875,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":646.199951171875,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":646.199951171875,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":646.199951171875,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":646.199951171875,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":646.199951171875,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":846.199951171875,\"y\":-23.700000762939454,\"z\":-146.9000244140625},{\"x\":846.199951171875,\"y\":-23.700000762939454,\"z\":-346.9000244140625},{\"x\":846.199951171875,\"y\":-23.700000762939454,\"z\":-546.9000244140625},{\"x\":846.199951171875,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":846.199951171875,\"y\":-23.700000762939454,\"z\":-946.9000244140625},{\"x\":846.199951171875,\"y\":-23.700000762939454,\"z\":253.0999755859375},{\"x\":846.199951171875,\"y\":-23.700000762939454,\"z\":453.0999755859375},{\"x\":846.199951171875,\"y\":-23.700000762939454,\"z\":53.0999755859375},{\"x\":846.199951171875,\"y\":-23.700000762939454,\"z\":653.0999145507813},{\"x\":846.199951171875,\"y\":-23.700000762939454,\"z\":853.0999145507813},{\"x\":1046.199951171875,\"y\":-23.700000762939454,\"z\":-746.9000244140625},{\"x\":1145.92431640625,\"y\":-0.5600008964538574,\"z\":-618.5240478515625},{\"x\":1163.1600341796875,\"y\":0.23999929428100587,\"z\":-620.4199829101563},{\"x\":1228.6871337890625,\"y\":70.24559020996094,\"z\":-603.2738037109375},{\"x\":1055.6240234375,\"y\":600.9880981445313,\"z\":-727.1297607421875},{\"x\":1180.2099609375,\"y\":-7.320000171661377,\"z\":-127.94999694824219},{\"x\":1203.260009765625,\"y\":0.5499992370605469,\"z\":-595.8899536132813},{\"x\":1739.0,\"y\":-9.0,\"z\":314.0},{\"x\":1203.260009765625,\"y\":0.5499992370605469,\"z\":-595.8899536132813}],\"name\":[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,159,160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,176,177,178,179,180,181,182,183,184,185,186,187,188,189,190,191,192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207,208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,224,225,226]}";
        //// string test = "{\"vector\":[{\"x\":1155.8199462890625,\"y\":-0.8899999856948853,\"z\":-625.739990234375},{\"x\":1140.780029296875,\"y\":-0.3700000047683716,\"z\":-625.739990234375},{\"x\":1140.780029296875,\"y\":-0.15000000596046449,\"z\":-636.0999755859375},{\"x\":1120.199951171875,\"y\":11.449999809265137,\"z\":-656.8399658203125},{\"x\":1120.199951171875,\"y\":2.9200000762939455,\"z\":-647.0999755859375},{\"x\":1140.780029296875,\"y\":0.800000011920929,\"z\":-647.0999755859375},{\"x\":1140.780029296875,\"y\":4.760000228881836,\"z\":-657.4599609375},{\"x\":1155.8199462890625,\"y\":2.9000000953674318,\"z\":-591.3800048828125},{\"x\":1155.8199462890625,\"y\":-0.8999999761581421,\"z\":-581.6400146484375},{\"x\":1176.4000244140625,\"y\":-5.28000020980835,\"z\":-581.6400146484375},{\"x\":1176.4000244140625,\"y\":-2.440000057220459,\"z\":-592.0},{\"x\":1176.4000244140625,\"y\":1.399999976158142,\"z\":-625.739990234375},{\"x\":1155.8199462890625,\"y\":-1.100000023841858,\"z\":-612.739990234375},{\"x\":1155.8199462890625,\"y\":1.5,\"z\":-603.0},{\"x\":1176.4000244140625,\"y\":-0.18000000715255738,\"z\":-603.0},{\"x\":1176.4000244140625,\"y\":1.4500000476837159,\"z\":-613.3599853515625},{\"x\":1120.199951171875,\"y\":1.090000033378601,\"z\":-591.3800048828125},{\"x\":1120.199951171875,\"y\":-0.5,\"z\":-581.6400146484375},{\"x\":1140.780029296875,\"y\":1.2999999523162842,\"z\":-581.6400146484375},{\"x\":1140.780029296875,\"y\":3.9100000858306886,\"z\":-592.0},{\"x\":1120.199951171875,\"y\":1.5,\"z\":-612.739990234375},{\"x\":1120.199951171875,\"y\":3.299999952316284,\"z\":-603.0},{\"x\":1176.4000244140625,\"y\":2.200000047683716,\"z\":-636.0999755859375},{\"x\":1140.780029296875,\"y\":3.4000000953674318,\"z\":-603.0},{\"x\":1140.780029296875,\"y\":1.3600001335144044,\"z\":-613.3599853515625},{\"x\":1098.800048828125,\"y\":3.9000000953674318,\"z\":-613.3599853515625},{\"x\":1098.800048828125,\"y\":2.0399999618530275,\"z\":-593.5999755859375},{\"x\":1098.800048828125,\"y\":-4.300000190734863,\"z\":-578.5},{\"x\":1098.800048828125,\"y\":6.300000190734863,\"z\":-630.4000244140625},{\"x\":1195.300048828125,\"y\":-2.799999952316284,\"z\":-581.6400146484375},{\"x\":1195.300048828125,\"y\":1.5,\"z\":-596.8099975585938},{\"x\":1195.300048828125,\"y\":7.699999809265137,\"z\":-614.9000244140625},{\"x\":1195.300048828125,\"y\":12.699999809265137,\"z\":-633.2000122070313},{\"x\":1155.8199462890625,\"y\":2.7799999713897707,\"z\":-656.8399658203125},{\"x\":1195.300048828125,\"y\":-8.0,\"z\":-559.9000244140625},{\"x\":1195.300048828125,\"y\":-12.800000190734864,\"z\":-534.2999877929688},{\"x\":1195.300048828125,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1161.5,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1127.800048828125,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1098.800048828125,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1161.5,\"y\":-14.199999809265137,\"z\":-527.5},{\"x\":1127.800048828125,\"y\":-14.199999809265137,\"z\":-527.5},{\"x\":1098.800048828125,\"y\":-14.199999809265137,\"z\":-527.5},{\"x\":1195.300048828125,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1155.8199462890625,\"y\":0.20000000298023225,\"z\":-647.0999755859375},{\"x\":1161.5,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1127.800048828125,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1098.800048828125,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1195.300048828125,\"y\":-16.450000762939454,\"z\":-439.8399963378906},{\"x\":1161.5,\"y\":-16.530000686645509,\"z\":-439.8399963378906},{\"x\":1127.800048828125,\"y\":-17.459999084472658,\"z\":-439.8399963378906},{\"x\":1098.800048828125,\"y\":-18.729999542236329,\"z\":-439.8399963378906},{\"x\":1294.7999267578125,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1261.0999755859375,\"y\":-15.800000190734864,\"z\":-502.6000061035156},{\"x\":1232.0999755859375,\"y\":-15.460000038146973,\"z\":-502.6000061035156},{\"x\":1176.4000244140625,\"y\":3.0,\"z\":-647.0999755859375},{\"x\":1294.7999267578125,\"y\":-14.199999809265137,\"z\":-527.5},{\"x\":1261.0999755859375,\"y\":-14.199999809265137,\"z\":-527.5},{\"x\":1232.0999755859375,\"y\":-13.0,\"z\":-527.5},{\"x\":1328.5999755859375,\"y\":-12.5600004196167,\"z\":-475.1000061035156},{\"x\":1294.7999267578125,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1261.0999755859375,\"y\":-16.100000381469728,\"z\":-475.1000061035156},{\"x\":1232.0999755859375,\"y\":-15.800000190734864,\"z\":-475.1000061035156},{\"x\":1328.5999755859375,\"y\":-6.599999904632568,\"z\":-439.8399963378906},{\"x\":1294.7999267578125,\"y\":-10.4399995803833,\"z\":-439.8399963378906},{\"x\":1261.0999755859375,\"y\":-13.09000015258789,\"z\":-439.8399963378906},{\"x\":1176.4000244140625,\"y\":3.8000001907348635,\"z\":-657.4599609375},{\"x\":1232.0999755859375,\"y\":-14.710000038146973,\"z\":-439.8399963378906},{\"x\":1061.300048828125,\"y\":-18.100000381469728,\"z\":-534.2999877929688},{\"x\":1061.300048828125,\"y\":-20.09000015258789,\"z\":-502.6000061035156},{\"x\":1027.5,\"y\":-21.100000381469728,\"z\":-502.6000061035156},{\"x\":993.800048828125,\"y\":-21.100000381469728,\"z\":-502.6000061035156},{\"x\":964.800048828125,\"y\":-21.100000381469728,\"z\":-502.6000061035156},{\"x\":1027.5,\"y\":-21.729999542236329,\"z\":-527.5},{\"x\":993.800048828125,\"y\":-22.639999389648439,\"z\":-527.5},{\"x\":964.800048828125,\"y\":-22.530000686645509,\"z\":-527.5},{\"x\":1061.300048828125,\"y\":-20.15999984741211,\"z\":-475.1000061035156},{\"x\":1120.199951171875,\"y\":0.7900000214576721,\"z\":-635.47998046875},{\"x\":1027.5,\"y\":-21.100000381469728,\"z\":-475.1000061035156},{\"x\":993.800048828125,\"y\":-21.100000381469728,\"z\":-475.1000061035156},{\"x\":964.800048828125,\"y\":-21.100000381469728,\"z\":-475.1000061035156},{\"x\":1061.300048828125,\"y\":-20.15999984741211,\"z\":-439.8399963378906},{\"x\":1027.5,\"y\":-21.100000381469728,\"z\":-439.8399963378906},{\"x\":993.800048828125,\"y\":-21.100000381469728,\"z\":-439.8399963378906},{\"x\":964.800048828125,\"y\":-21.100000381469728,\"z\":-439.8399963378906},{\"x\":1120.199951171875,\"y\":1.4900000095367432,\"z\":-625.739990234375},{\"x\":1155.8199462890625,\"y\":-0.8899999856948853,\"z\":-635.47998046875}],\"name\":[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86]}";
        //string test = File.ReadAllText(Application.streamingAssetsPath + "/JSON.json");// для теста

        string test = "{\"aid\":\"a77d8c75f89da60e1252c4467aabff3bb55f11fe3b642f084b5741634ed20f87\",\r\n\"equipment\":[5,3,3,4,5],\r\n\"name\":\"TestMode\",\r\n \"quest\":[{\"questStep\":0,\"dialog_count\":0,\"recipe\":\"false\"},\r\n\t\t\t{\"scroll\":0,\"vector\":[]}],\r\n\"experience\":\"0\",\r\n\"charId\":\"yvfl5-aikor-uwiaa-aaaaa-dmaau-4aqca-aaaii-q\"}";

        string read_file = "{\"experience\": 100,\r\n\"level\": 1,\r\n\"strength\": 50,\r\n\"attack\" : 50,\r\n\"st_resist\" : 5,\r\n\"hp_regen\" : 2.5,\r\n\"dexterity\" : 30,\r\n\"attack_speed\" : 30,\r\n\"evasion\" : 3,\r\n\"accuracy\" : 3,\r\n\"intelligence\" : 40,\r\n\"m_attack\" : 40,\r\n\"mp_regen\" : 2,\r\n\"move_speed\" : 80,\r\n\"initial_attack_speed\" : 600,\r\n\"initial_evasion\" : 0,\r\n\"initial_accuracy\" : 70,\r\n\"critical_chance\" : 0,\r\n\"spell_speed\" : 0,\r\n\"cooldown\" : 0,\r\n\"defence\" : 0,\r\n\"m_resist\" : 0,\r\n\"set_bonus\" : 0}";


        Load_json_Attributes(read_file);// для теста
        Load_json(test);// для теста

        //Save_atribute();
        //Save_json();
        //Debug.Log("!!");
        //string Out_mess2 = "{\r\n    \"equipment\": [5,3,3,4,5],\r\n    \"name\": \"Leviton3#D530\",\r\n    \"quest\": [\r\n        {\"questStep\":0,\"dialog_count\":0,\"recipe\":\"false\"},\r\n        {\"scroll\":0, \"vector\":[]}],    \r\n    \"charId\": \"yvfl5-aikor-uwiaa-aaaaa-dmaau-4aqca-aaaii-q\",\r\n    \"position\": [0,0,0]\r\n}";
        //File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", Out_mess2);// для тестаJsonUtility.ToJson(root)

        //Debug.Log(Out_mess2);
        //obj_xz_item = JsonUtility.FromJson<OBJ_XZ>(read_file);

        //load_obj_xz(vector_player);
    }

    [Serializable]
    public class MAT_LIST
    {       
        //public List<Material> materials;
        public List<string> list;
        public List<string> materials;
       
    }

    [Serializable]
    public class OBJ_XZ
    {
        //public string[] Items;
        public Dictionary<int, Vector3> XZ;
        public List<Vector3> vector;
        public List<int> name;
    }

    [Serializable]
    public class Quest
    {
        public int questStep;
        public int dialog_count;
        public string recipe;
        public int scroll;
        public Vector3[] vector;

        public Quest(int questStep, int dialog_count, string recipe, int scroll, Vector3[] vector)//, int scroll, Vector3[] vector
        {
            this.questStep = questStep;
            this.dialog_count = dialog_count;
            this.recipe = recipe;
            this.scroll = scroll;
            this.vector = vector;
        }
    }

    [Serializable]
    public class Root
    {
        public string aid;
        public List<int> equipment;
        public string name;
        public List<Quest> quest;
        public Vector3[] position;
        public string charId;

    }
    [Serializable]
    public class Root2
    {
        public int experience;
        public int level;
        public int strength;
        public int attack;
        public int st_resist;
        public float hp_regen;
        public int dexterity;
        public int attack_speed;
        public int evasion;
        public int accuracy;
        public int intelligence;
        public int m_attack;
        public int mp_regen;
        public int move_speed;
        public int initial_attack_speed;
        public int initial_evasion;
        public int initial_accuracy;
        public int critical_chance;
        public int spell_speed;
        public int cooldown;
        public int defence;
        public int m_resist;
        public int set_bonus;
    }
    [Serializable]
    public class Root3
    {
        public int icp;
        public int gold;
        public int coal;
        public int ore;
        public int adit;
        public int lgs;
        public int leather;
        public int bronze;
        public int tp;

    }
    private void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    string read_file = File.ReadAllText(Application.streamingAssetsPath + "/JSON_mat.json");// для теста
        //                                                                                            //string read_file = File.ReadAllText(Application.streamingAssetsPath + "/JSON_mat.json");// для теста
        //                                                                                            //string read_file = "{\"list\":[\"DF_C_Big_Bridge_1\",\"DF_C_Big_Bridge_2\",\"DF_C_Big_Bridge_3_1\",\"DF_C_Big_Bridge_3_2\",\"DF_C_Big_Bridge_3_3\"],\"materials\":[\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Tile_model_floor_1\",\"M_DF_C_Trim_model_borders_set_1\",\"M_DF_C_Tile_model_brick_set_1\",\"M_DF_C_Tile_model_floor_1\"]}";
        //                                                                                            //string[] data = File.ReadAllLines(Application.streamingAssetsPath + "/JSON_mat.json");

        //    //for (int i = 0; i < data.Length; i++)
        //    //{
        //    //    mat_root = JsonUtility.FromJson<MAT_LIST>(data[i]); //Десериализуем из JSON в объект
        //    //    Debug.Log(data[i]);

        //    //}

        //    mat_root = JsonUtility.FromJson<MAT_LIST>(read_file);

        //    //name_obj_mat = mat_root.list_name_obj;
        //    Debug.Log(mat_root.list.Count);
        //    //Debug.Log(read_file);
        //}

    }
}

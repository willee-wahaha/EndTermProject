using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSheet : MonoBehaviour
{
    public static int[] music1 = { 0, 2, 2,
                                    0, 3, 3,
                                    2, 5, 1
                                };
    public static int[] music2 = { 0, 3, 2,
                                    1, 1, 2,
                                    2, 3, 1
                                };
    public static int[][] musicSheet = { music1, music2};

    public static float speed = 1;
}

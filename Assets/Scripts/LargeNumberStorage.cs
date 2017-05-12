using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class LargeNumberStorage
{
    public List<int> number;
    public static List<int> operator +(LargeNumberStorage a, LargeNumberStorage b)
    {
        LargeNumberStorage larger = (a.number.Count > b.number.Count) ? a : b;
        LargeNumberStorage smaller = (larger == a) ? b : a;
        for (int i = (larger.number.Count - smaller.number.Count); i < larger.number.Count; i++)
        {
            larger.number[i] = smaller.number[i - (larger.number.Count - smaller.number.Count)] + larger.number[i];
        }
        for (int i = larger.number.Count - 1; i > -1; i--)
        {
            if (larger.number[i] > 9)
            {
                int num = larger.number[i];
                int carry = (int)num / 10;
                if (i != 0)
                {
                    larger.number[i - 1] += carry;
                    larger.number[i] = larger.number[i] % 10;
                }
                else
                {
                    larger.number.Insert(0, carry);
                    larger.number[i + 1] = larger.number[i] % 10;
                }
            }
        }
        return larger.number;
    }

}


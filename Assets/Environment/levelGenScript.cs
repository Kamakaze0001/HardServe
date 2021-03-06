﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenScript : MonoBehaviour
{
    const bool H = false;
    const bool T = true;

    bool[,,] tileRules =
    {
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,H,T,T,T,T,H,H,T,T,T,T,H,T},
            {T,T,T,H,T,T,T,T,T,T,H,T,T,T},
            {T,T,T,H,T,T,T,T,T,T,H,T,T,T},
            {T,H,T,T,T,T,H,H,T,T,T,T,H,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//1
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,H,T,T,T,T,T,T,T,T,T,T,H,T},
            {T,H,H,T,T,H,H,H,H,T,T,H,H,T},
            {T,H,H,T,T,H,H,H,H,T,T,H,H,T},
            {T,H,T,T,T,T,T,T,T,T,T,T,H,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//2
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,H,T,T,H,T,T,T,T,T},
            {T,T,T,T,T,H,T,T,H,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//3
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,H,H,T,T,T,T,T,H,T,T,T},
            {T,T,T,H,T,T,T,T,T,H,H,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//4
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,H,T,T,T,T,H,T,T,T,H,T},
            {T,H,T,H,T,H,T,T,H,T,H,T,H,T},
            {T,H,T,H,T,H,T,T,H,T,H,T,H,T},
            {T,H,T,T,T,H,T,T,T,T,H,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//5
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,H,H,T,T,T,T,T,T,H,H,T,T},
            {T,T,H,H,T,T,T,T,T,T,H,H,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//6
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,H,T,T,T,T,T,T,H,T,T,T,T},
            {T,T,H,H,T,T,T,T,T,H,H,T,T,T},
            {T,T,T,H,H,T,T,T,T,T,H,H,T,T},
            {T,T,T,T,H,T,T,T,T,T,T,H,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//7
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//8
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,H,H,T,T,T,T,T,T,H,H,T,T},
            {T,T,T,T,H,T,T,T,T,H,T,T,T,T},
            {T,T,T,T,H,T,T,T,T,H,T,T,T,T},
            {T,T,H,H,T,T,T,T,T,T,H,H,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//9
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//10
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//11
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,H,T,T,T,T,T,T,H,T,T,T},
            {T,T,T,H,T,T,T,T,T,T,H,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//12
        {   {T,T,T,T,H,T,T,T,T,H,T,T,T,T},
            {H,H,H,H,H,T,T,T,T,H,H,H,H,H},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {H,H,H,H,H,T,T,T,T,H,H,H,H,H},
            {T,T,T,T,H,T,T,T,T,H,T,T,T,T}},//13
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,H,T,T,T,T,T,T,T,T,H,T,T},
            {T,T,T,H,T,T,T,T,T,T,H,T,T,T},
            {T,T,T,H,T,T,T,T,T,T,H,T,T,T},
            {T,T,H,T,T,T,T,T,T,T,T,H,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//14
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//15
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,H,T,H,T,H,H,T,H,T,H,T,T},
            {T,T,H,T,H,T,T,T,T,H,T,H,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//16
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,H,T,T,H,T,T,T,T,T},
            {T,T,T,T,T,H,T,T,H,T,T,T,T,T},
            {T,T,T,T,T,H,T,T,H,T,T,T,T,T},
            {T,T,T,T,H,H,T,T,H,H,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//17
        {   {T,T,T,T,H,H,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,H,H,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,H,H,T,T,T,T,T,H,H,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//18
        {   {T,H,T,T,T,T,T,T,T,T,T,T,T,H},
            {T,H,T,T,T,T,T,T,T,T,T,T,T,H},
            {T,T,T,T,T,T,T,T,H,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,H,T,T,T,T,T},
            {T,T,H,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,H,T,T,T,T,T,T,T,T,T,T,T}},//19
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//20
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,H,T,T,T,T,H,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,H,T,T,T,T,H,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//21
        {   {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,H,H,H,H,H,H,H,H,H,H,T,T},
            {T,T,H,H,H,H,H,H,H,H,H,H,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T}},//22
        {   {T,T,H,H,T,T,T,T,T,T,H,H,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,H,H,T,T,T,T,T,T,H,H,T,T}},//23
        {   {H,T,T,T,T,T,T,T,T,T,T,T,T,H},
            {H,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,T},
            {T,T,T,T,T,T,T,T,T,T,T,T,T,H},
            {H,T,T,T,T,T,T,T,T,T,T,T,T,H}}//24
    };

    bool[,,] stoolRules =
    {
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//1
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,T,T,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,T,T,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//2
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,T,H,T,H,T,H,H,T,H,T,H,T,H},
            {H,H,T,H,H,H,H,H,H,H,H,T,H,H},
            {H,H,T,H,H,H,H,H,H,H,H,T,H,H},
            {H,T,H,T,H,T,H,H,T,H,T,H,T,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//3
        {   {T,T,H,H,H,H,H,H,H,H,H,H,T,T},
            {T,H,H,H,H,H,H,H,H,H,H,H,H,T},
            {H,H,H,H,H,H,H,H,T,H,H,H,H,H},
            {H,H,H,H,H,T,H,H,H,H,H,H,H,H},
            {T,H,H,H,H,H,H,H,H,H,H,H,H,T},
            {T,T,H,H,H,H,H,H,H,H,H,H,T,T}},//4
        {   {H,H,H,T,H,H,H,H,T,H,H,H,T,H},
            {H,T,H,H,H,T,H,H,H,H,T,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,T,H,H,H,T,H},
            {H,T,H,H,H,T,H,H,H,H,T,H,H,H}},//5
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,T,H,H,T,H,H,H,T,H,H,H},
            {H,H,H,H,T,H,H,H,H,T,H,H,H,H},
            {H,H,H,H,T,H,H,H,H,T,H,H,H,H},
            {H,H,H,T,H,H,H,T,H,H,T,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//6
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,T,H,H,H,T,H,H,T,H,H,H,T,H},
            {H,H,H,H,H,H,T,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,T,H,H,H,H,H,H},
            {H,T,H,H,H,T,H,H,T,H,H,H,T,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//7
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,T,H,H,H,H,H,H,H,H,H,H,T,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,T,H,H,H,H,H,H,H,H,H,H,T,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//8
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,T,T,H,H,H,H,H,H,H,H,T,T,H},
            {H,H,H,T,T,H,H,H,H,T,T,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//9
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//10
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//11
        {   {T,T,T,T,T,H,H,H,H,T,T,T,T,T},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {T,T,T,T,T,H,H,H,H,T,T,T,T,T}},//12
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//13
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,T,H,T,H,H,H,H,H,H},
            {H,H,H,H,H,H,T,H,T,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//14
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,T,T,T,T,T,T,T,T,T,T,H,H},
            {H,H,T,H,H,H,H,H,H,H,H,T,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//15
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,T,H,H,H,T,H,H,T,H,H,H,T,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,T,H,H,H,H,H,H,T,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//16
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//17
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,T,T,H,H,H,H,H,T,T,H,H,H,H},
            {H,H,H,H,H,T,T,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,T,T,H,H,H,H,H,H},
            {H,T,T,H,H,H,H,H,H,H,H,T,T,H}},//18
        {   {H,H,H,H,H,T,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,T,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,T,H,H,H,H,H,H,T,H,H},
            {H,H,H,H,T,H,H,H,H,H,H,T,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//19
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,T,H,H,T,H,H,T,H,H,T,H,H,T},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {T,H,H,T,H,H,T,H,H,T,H,H,T,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//20
        {   {H,H,H,H,H,T,H,H,T,H,H,H,H,H},
            {T,T,H,H,H,T,H,H,T,H,H,H,T,T},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {T,T,H,H,H,T,H,H,T,H,H,H,T,T},
            {H,H,H,H,H,T,H,H,T,H,H,H,H,H}},//21
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//22
        {   {T,T,H,H,H,H,H,H,H,H,H,H,T,T},
            {T,T,H,H,H,H,H,H,H,H,H,H,T,T},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {T,T,H,H,H,H,H,H,H,H,H,H,T,T},
            {T,T,H,H,H,H,H,H,H,H,H,H,T,T}},//23
        {   {H,H,H,H,H,H,H,H,H,H,H,H,H,H},
            {H,H,H,T,H,H,H,H,H,H,T,T,T,T},
            {H,H,H,T,H,H,H,H,H,H,T,H,H,H},
            {H,H,H,T,H,H,H,H,H,H,T,H,H,H},
            {T,T,T,T,H,H,H,H,H,H,T,H,H,H},
            {H,H,H,H,H,H,H,H,H,H,H,H,H,H}},//24
    };

    [SerializeField]
    private Transform wallParent, groundParent, holeParent, stoolParent, doorParent, enemyParent;

    [SerializeField]
    private GameObject wallStraight, wallCorner, groundTile, hole, stool, door;

    [SerializeField]
    private List<GameObject> enemies;

    [SerializeField]
    private GameObject player, AStarObject;

    private const int levelRadiusH = 3, levelRadiusW = 7;

    private Vector2 levelPos = new Vector2(0.0f, 0.0f);
    private List<GameObject> doors;
    private List<Vector2> vistedRooms;

    private float timeSinceLevelLoad = 0.0f;

    public Vector2 moveLevelPos(Vector2 v)
    {
        return levelPos += v;
    }

    public void LoadLevel(Vector2 lp)
    {
		print(levelPos);

        foreach (Transform child in wallParent  ) Destroy(child.gameObject);
        foreach (Transform child in groundParent) Destroy(child.gameObject);
        foreach (Transform child in holeParent  ) Destroy(child.gameObject);
        foreach (Transform child in stoolParent ) Destroy(child.gameObject);
        doors = new List<GameObject>();
        foreach (Transform child in doorParent) Destroy(child.gameObject);

        Random.State oldState = Random.state;
        Random.InitState(Mathf.FloorToInt(hash21(lp) * 1000000.0f));

        bool[,] tiles = new bool[levelRadiusW * 2, levelRadiusH * 2];
        bool[,] stools = new bool[levelRadiusW * 2, levelRadiusH * 2];

        int roomRule = Random.Range(0, 24);

        //Corners
        Instantiate(wallCorner, new Vector3(-levelRadiusW, -levelRadiusH + 1), Quaternion.Euler(0.0f, 0.0f, 90.0f), wallParent);
        Instantiate(wallCorner, new Vector3(levelRadiusW, 1 - levelRadiusH), Quaternion.Euler(0.0f, 0.0f, 180.0f), wallParent);
        Instantiate(wallCorner, new Vector3(levelRadiusW, 1 + levelRadiusH), Quaternion.Euler(0.0f, 0.0f, -90.0f), wallParent);
        Instantiate(wallCorner, new Vector3(- levelRadiusW, 1 + levelRadiusH), Quaternion.Euler(0.0f, 0.0f, 0.0f), wallParent);
        //Fill
        for (int x = 0; x < levelRadiusW * 2; x++)
        {
            //Bottom wall
            Instantiate(wallStraight, new Vector3(1 + x - levelRadiusW, -levelRadiusH), Quaternion.Euler(0.0f, 0.0f, 180.0f), wallParent);

            for (int y = 0; y < levelRadiusH * 2; y++)
            {
                //Setting tile existence
                tiles[x, y] = tileRules[roomRule,y,x];
                stools[x, y] = stoolRules[roomRule,y,x];

                Instantiate(
                    tiles[x, y] ? groundTile : hole,
                    new Vector3(x - levelRadiusW, levelRadiusH + 1 - y),
                    Quaternion.identity,
                    tiles[x, y] ? groundParent : holeParent
                );

                //Stools
                if (tiles[x, y] && stools[x,y]) Instantiate(
                      stool,
                      new Vector3(x - levelRadiusW, levelRadiusH + 1 - y),
                      Quaternion.identity,
                      stoolParent
                  );

            }
            //Top Wall
            Instantiate(wallStraight, new Vector3(x - levelRadiusW, 2 + levelRadiusH), Quaternion.Euler(0.0f, 0.0f, 0.0f), wallParent);
        }
        for (int y = 0; y < levelRadiusH * 2; y++)
        {
            //Left wall
            Instantiate(wallStraight, new Vector3(-1 - levelRadiusW, levelRadiusH - y), Quaternion.Euler(0.0f, 0.0f, 90.0f), wallParent);
            //Right Wall
            Instantiate(wallStraight, new Vector3(1 + levelRadiusW, levelRadiusH + 1 - y), Quaternion.Euler(0.0f, 0.0f, -90.0f), wallParent);
        }

        foreach(Transform child in groundParent)
        {
            child.gameObject.GetComponent<SpriteRenderer>().sortingOrder = - 5 - levelRadiusH - (int)child.position.y;
        }

        if (hash21(levelPos + new Vector2(0.5f, 0.0f)) > 0.2f)
        {
            doors.Add(Instantiate(door, new Vector3(1 + levelRadiusW, 1.5f), Quaternion.Euler(0.0f, 0.0f, -90.0f), doorParent));
            doors[doors.Count - 1].GetComponent<doorControl>().setDirection(new Vector2(1.0f, 0.0f));
        }
        if (hash21(levelPos + new Vector2(-0.5f, 0.0f)) > 0.2f)
        {
            doors.Add(Instantiate(door, new Vector3(-1 - levelRadiusW, 0.5f), Quaternion.Euler(0.0f, 0.0f, 90.0f), doorParent));
            doors[doors.Count - 1].GetComponent<doorControl>().setDirection(new Vector2(-1.0f, 0.0f));
        }
        if (hash21(levelPos + new Vector2(0.0f, 0.5f)) > 0.2f)
        {
            doors.Add(Instantiate(door, new Vector3(-0.5f, 2 + levelRadiusH), Quaternion.Euler(0.0f, 0.0f, 0.0f), doorParent));
            doors[doors.Count - 1].GetComponent<doorControl>().setDirection(new Vector2(0.0f, 1.0f));
        }
        if (hash21(levelPos + new Vector2(0.0f, -0.5f)) > 0.2f)
        {
            doors.Add(Instantiate(door, new Vector3(0.5f, -levelRadiusH), Quaternion.Euler(0.0f, 0.0f, 180.0f), doorParent));
            doors[doors.Count - 1].GetComponent<doorControl>().setDirection(new Vector2(0.0f, -1.0f));
        }

		if (!vistedRooms.Contains(lp)){
			vistedRooms.Add(lp);
			int enemyNum = 1;
			int enemyChance = 0;

			List<Transform> possiblePositions = new List<Transform>((Transform[])groundParent.GetComponentsInChildren<Transform>().Clone());
            foreach(Transform t1 in stoolParent.GetComponentsInChildren<Transform>())
            {
                foreach(Transform t2 in possiblePositions)
                {
                    if( (t1.position - t2.position).sqrMagnitude < 0.5f)
                    {
                        possiblePositions.Remove(t2);
                        break;
                    }
                }
            }

			while (enemyChance < 1){
				int posInd = Random.Range(0, possiblePositions.Count);

				Vector3 prefabPos = possiblePositions[posInd].position + new Vector3(0.5f, -0.5f, 0.0f);

				possiblePositions.RemoveAt(posInd);

				GameObject temp = Instantiate(enemies[Random.Range(0, enemies.Count)], prefabPos, Quaternion.identity, enemyParent);
				if (temp.GetComponent<EnemyAI>() != null)
				{
					temp.GetComponent<EnemyAI>().target = player.transform;
					temp.GetComponent<EnemyAI>().AstarObj = AStarObject.GetComponent<AstarPath>();
				}

				enemyChance = Random.Range(0, ++enemyNum);
			}
		}

        Random.state = oldState;
        timeSinceLevelLoad = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        vistedRooms = new List<Vector2>();
        levelPos = new Vector2(Random.value, Random.value);
        vistedRooms.Add(levelPos);
        LoadLevel(levelPos);
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
    }

    bool IsHole(int x, int y, int rule)
    {
        switch (rule)
        {
            case 0:
                return (x == 1 || x == 2 * levelRadiusW - 2) && (y != 0 && y != levelRadiusH * 2 - 1);
            case 1:
                return (y == 1 || y == 2 * levelRadiusH - 2) && (x != 0 && x != levelRadiusW * 2 - 1 && x != 1 && x != levelRadiusW * 2 - 2);
            case 2:
                return (x == levelRadiusW || x == levelRadiusW - 1) && (y == levelRadiusH || y == levelRadiusH - 1);
            case 3:
                return (x == levelRadiusW - 2 || x == levelRadiusW + 1) && (y != 0 && y != levelRadiusH * 2 - 1) || (x == levelRadiusW - 3 && y == levelRadiusH + 1) || (x == levelRadiusW + 2 && y == levelRadiusH + 1);
            case 4:
                return false;
        }
        return false;
    }

    bool IsStool(int x, int y, int rule)
    {
        switch (rule)
        {
            case 0:
                return (x + y * 13) % 18 == 0;
            case 1:
                return (x == 0 && y == 0) || (x == levelRadiusW * 2 - 1 && y == levelRadiusH * 2 - 1) || (x == levelRadiusW || x == levelRadiusW - 1) && (y == levelRadiusH || y == levelRadiusH - 1); ;
            case 2:
                return false;
            case 3:
                return false;
            case 4:
                return false;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLevelLoad += Time.deltaTime;
    }

    float fract(float f)
    {
        return f - Mathf.Floor(f);
    }

    Vector2 fract(Vector2 v)
    {
        return new Vector2(fract(v.x), fract(v.y));
    }

    float hash21(Vector2 p)
    {
        return fract(Mathf.Sin(Vector2.Dot(p, new Vector2(12.9898f, 78.233f) * 43758.5453123f)));
    }

    public bool finished()
    {
        return timeSinceLevelLoad > 1.0f && enemyParent.transform.childCount == 0;
    }

}


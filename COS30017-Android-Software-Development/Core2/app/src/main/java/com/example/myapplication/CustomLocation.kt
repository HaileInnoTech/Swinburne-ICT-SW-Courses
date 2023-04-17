package com.example.myapplication

import android.os.Parcelable
import kotlinx.parcelize.Parcelize
@Parcelize
data class CustomLocation(val name: String,val city: String,val rate: Int, val longitude:
Double, val latitude: Double, val isVisited: Boolean, val image: Int):
    Parcelable {

}


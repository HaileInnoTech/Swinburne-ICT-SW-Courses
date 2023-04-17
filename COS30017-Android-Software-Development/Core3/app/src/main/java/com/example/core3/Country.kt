package com.example.core3

import android.os.Parcelable
import kotlinx.parcelize.Parcelize

@Parcelize
data class Country (val name: String, val code: String,
                    val times: Int, val golden: Int,
                    val silver: Int, val bronze: Int):
    Parcelable {

    }

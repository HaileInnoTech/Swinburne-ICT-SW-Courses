package com.example.lightmeup

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ImageView

class MainActivity : AppCompatActivity() {

    var light = R.drawable.ic_baseline_light_mode_on_24

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        val image = findViewById<ImageView>(R.id.light)

        image.setOnLongClickListener{
        light = when(light){
            R.drawable.ic_baseline_light_mode_on_24 -> R.drawable.ic_baseline_light_mode_24
            R.drawable.ic_baseline_light_mode_24 ->  R.drawable.ic_baseline_light_mode_on_24
            else -> R.drawable.ic_baseline_light_mode_24
        }
            image.setImageDrawable(getDrawable(light))
            true
        }
        image.setOnClickListener{
            light = when(light){// switch case if light is on click to turn off

                R.drawable.ic_baseline_light_mode_on_24 -> R.drawable.ic_baseline_light_mode_24
                R.drawable.ic_baseline_light_mode_24 ->  R.drawable.ic_baseline_light_mode_on_24
                else -> R.drawable.ic_baseline_light_mode_24
            }
            image.setImageDrawable(getDrawable(light)) // draw method to show

        }
}}
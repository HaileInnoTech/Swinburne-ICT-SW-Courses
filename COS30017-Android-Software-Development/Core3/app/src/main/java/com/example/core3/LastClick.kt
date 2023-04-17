package com.example.core3

import android.content.Context
import android.os.Bundle
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class LastClick : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.last_click)

        val last_click = findViewById<TextView>(R.id.lastclick)

        val sharedPreferences = getSharedPreferences("myPreferences", Context.MODE_PRIVATE)
        val country_name = sharedPreferences.getString("countryname", "")
        val country_code = sharedPreferences.getString("code","")
        last_click.text = getString(R.string.stt) + " " + country_name + " (" + country_code + ")"    }
}
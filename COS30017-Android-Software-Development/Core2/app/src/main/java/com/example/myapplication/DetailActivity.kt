package com.example.myapplication

import android.annotation.SuppressLint
import android.app.Activity
import android.content.Intent
import android.location.Location
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.TextView

class DetailActivity : AppCompatActivity() {
    private val da_lat =
        CustomLocation("Da Lat", "Da Lat", 5, 123.456, 789.012, true, R.drawable.da_lat)
    private val pig_hill = CustomLocation(
        "Pig Hill", "Vung Tau", 2, 456.789, 123.456, false, R.drawable.doi_con_heo
    )
    private val tri_an = CustomLocation(
        "Tri An Lake", "Dong Nai", 3, 789.012, 456.789, true, R.drawable.ho_tri_an
    )
    private val land_mark = CustomLocation(
        "Land Mark 81", "Ho CHi Minh", 4, 456.789, 123.456, false, R.drawable.landmark_81
    )

    companion object {
        const val dalat = 1 // Replace with your own value
        const val pighill = 2
        const val trian = 3
        const val landmark = 4
    }

    @SuppressLint("MissingInflatedId")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.page1)
        setTitle(R.string.title1)

        val vlandmark = findViewById<TextView>(R.id.vlandmark)
        val vpighill = findViewById<TextView>(R.id.vpighill)
        val vtrian = findViewById<TextView>(R.id.vtrian)
        val vdalat = findViewById<TextView>(R.id.vdalat)

        val rate_dalat = findViewById<TextView>(R.id.rate_dalat)
        rate_dalat.text = da_lat.rate.toString() + " stars"

        val rate_pighill = findViewById<TextView>(R.id.rate_pighill)
        rate_pighill.text = pig_hill.rate.toString() + " stars"

        val rate_trian = findViewById<TextView>(R.id.rate_trian)
        rate_trian.text = tri_an.rate.toString()+ " stars"

        val rate_landmark = findViewById<TextView>(R.id.rate_landmark)
        rate_landmark.text = land_mark.rate.toString()+ " stars"



        vdalat.setOnClickListener {
            val intent = Intent(this, ActivityInfo::class.java)
            intent.putExtra("location", da_lat)
            startActivityForResult(intent, dalat)
        }
        vlandmark.setOnClickListener {
            val intent = Intent(this, ActivityInfo::class.java)
            intent.putExtra("location", land_mark)
            startActivityForResult(intent, landmark)
        }
        vtrian.setOnClickListener {
            val intent = Intent(this, ActivityInfo::class.java)
            intent.putExtra("location", tri_an)
            startActivityForResult(intent, trian)
        }
        vpighill.setOnClickListener {
            val intent = Intent(this, ActivityInfo::class.java)
            intent.putExtra("location", pig_hill)
            startActivityForResult(intent, pighill)
        }
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)
        if (requestCode == dalat && resultCode == Activity.RESULT_OK) {
            val receivedValue = data?.getFloatExtra("ratingValue", 0F)
            val rate_dalat = findViewById<TextView>(R.id.rate_dalat)
            rate_dalat.text = receivedValue.toString()+ " stars"
        }
        if (requestCode == trian && resultCode == Activity.RESULT_OK) {
            val receivedValue = data?.getFloatExtra("ratingValue", 0F)
            val rate_trian = findViewById<TextView>(R.id.rate_trian)
            rate_trian.text = receivedValue.toString()+ " stars"
        }
        if (requestCode == pighill && resultCode == Activity.RESULT_OK) {
            val receivedValue = data?.getFloatExtra("ratingValue", 0F)
            val rate_pighill = findViewById<TextView>(R.id.rate_pighill)
            rate_pighill.text = receivedValue.toString()+ " stars"
        }
        if (requestCode == landmark && resultCode == Activity.RESULT_OK) {
            val receivedValue = data?.getFloatExtra("ratingValue", 0F)
            val rate_landmark = findViewById<TextView>(R.id.rate_landmark)
            rate_landmark.text = receivedValue.toString()+ " stars"
        }

    }
}
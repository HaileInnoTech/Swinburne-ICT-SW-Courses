package com.example.myapplication

import android.annotation.SuppressLint
import android.app.Activity
import android.app.Activity.RESULT_OK
import android.content.Intent
import android.os.Bundle
import android.telecom.Call
import android.widget.ImageView
import android.widget.RatingBar
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity


class ActivityInfo : AppCompatActivity() {

    private var rate = 0.0f

    companion object {
        const val REQUEST_CODE = 123
        const val RATING_KEY = "rating"
        const val STARS_KEY = "star"
    }

    @SuppressLint("MissingInflatedId", "SuspiciousIndentation")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.page2)
        setTitle(R.string.title2)

        val location = intent.getParcelableExtra<CustomLocation>("location")
        location?.let {
            val vimage = findViewById<ImageView>(R.id.vlocation)
            vimage.setImageResource(it.image)
            val vname = findViewById<TextView>(R.id.vname)
            vname.text = it.name
            val vcity = findViewById<TextView>(R.id.vcity)
            vcity.text = it.city
            val vcheck_visit = findViewById<TextView>(R.id.vcheck_visit)
            if (!it.isVisited) {
                vcheck_visit.text = "Not Visited"
            } else {
                vcheck_visit.text = "Visited"
            }

            val vrate = findViewById<RatingBar>(R.id.vrate)
            vrate.rating = it.rate.toFloat()
            rate = savedInstanceState?.getFloat(RATING_KEY) ?: it.rate.toFloat()
            vrate.rating = rate

            rate = it.rate.toFloat()

            vrate.setOnRatingBarChangeListener { ratingBar, rating, fromUser ->
                if (fromUser) {
                    Toast.makeText(this@ActivityInfo, "You rated: $rating", Toast.LENGTH_SHORT)
                        .show()
                    val intent = Intent()

                    intent.putExtra("ratingValue", rating)
                    setResult(Activity.RESULT_OK, intent)
                    finish()
                }


            }

        }
    }

    override fun onSaveInstanceState(outState: Bundle) {
        super.onSaveInstanceState(outState)
        outState.putFloat(RATING_KEY, rate)
    }
}














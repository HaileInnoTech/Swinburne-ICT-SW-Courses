package com.example.core1
import android.annotation.SuppressLint
import android.media.MediaPlayer
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.os.Handler
import android.os.PersistableBundle
import android.util.Log
import android.widget.Button
import android.widget.TextView
import androidx.core.content.ContextCompat
import androidx.lifecycle.Lifecycle



class MainActivity : AppCompatActivity() {
    var num= 0
    override fun onStop() {
        super.onStop()
        Log.i("LIFECYCLE","stopped")
    }

    override fun onDestroy() {
        super.onDestroy()
        Log.i("LifeCYCLE", "destroyed")
    }

    @SuppressLint("SuspiciousIndentation")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val increase = findViewById<Button>(R.id.increase)
        val decrease = findViewById<Button>(R.id.decrease)
        val reset = findViewById<Button>(R.id.reset)
        val answer = findViewById<TextView>(R.id.answer)

        val increase_sound = MediaPlayer.create(this, R.raw.beep)
        val decrease_sound = MediaPlayer.create(this,R.raw.bip)
        val reset_sound = MediaPlayer.create(this,R.raw.monster_sound)
        val win_sound = MediaPlayer.create(this,R.raw.oh_yeah)

        savedInstanceState?.let{
            num = it.getInt("count_key")
            answer.setText(this.num.toString())
        }

        increase.setOnClickListener{
            if(num<15){num++}

            if(num == 15){ win_sound.start() }
            else
            increase_sound.start()

            answer.setText(num.toString())
            changeTextColor(answer,num)

        }
        decrease.setOnClickListener {
            if(num > 0){num--}

            decrease_sound.start()

            answer.setText(num.toString())
            changeTextColor(answer,num)

        }
        reset.setOnClickListener{
            reset_sound.start()
            num = 0
            changeTextColor(answer,num)
            answer.setText(num.toString())

        }

    }
    override fun onSaveInstanceState(outState: Bundle) {
        super.onSaveInstanceState(outState)
        Log.i("MyTag", "Number saved")
        outState.putInt("count_key", num)

    }
    override fun onRestoreInstanceState(savedInstanceState: Bundle) {
        super.onRestoreInstanceState(savedInstanceState)
        Log.i("MyTag", "Number restored")

        num = savedInstanceState.getInt("count_key",0)


    }
}

fun changeTextColor(scoreTextView: TextView, num: Int) {
    if (num in 5..9) {
        scoreTextView.setTextColor(ContextCompat.getColor(scoreTextView.context, R.color.blue))
    } else if(num in 10..15 ){
        scoreTextView.setTextColor(ContextCompat.getColor(scoreTextView.context, R.color.green))
    }
        else {
        scoreTextView.setTextColor(ContextCompat.getColor(scoreTextView.context, R.color.black))
    }
}



package com.example.core3

import android.annotation.SuppressLint
import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.Menu
import android.view.MenuItem
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.opencsv.CSVReader
import java.io.InputStreamReader

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        val data = initData()

        val list = findViewById<RecyclerView>(R.id.list)
        list.adapter = CountryAdapter(data)
        list.layoutManager = LinearLayoutManager(this)


    }

    private fun initData(): List<Country> {
        val csvReader = CSVReader(InputStreamReader(resources.openRawResource(R.raw.medallists)))
        val allRows = csvReader.readAll()
        return allRows.drop(1).map {
            Country(it[0], it[1], it[3].toInt(), it[4].toInt(), it[5].toInt(), it[5].toInt())
        }
    }
    override fun onCreateOptionsMenu(menu: Menu): Boolean {
        // Inflate the menu; this adds items to the action bar if it is present.
        menuInflater.inflate(R.menu.menu, menu)
        return true
    }
    @SuppressLint("CommitPrefEdits")
    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        when (item.itemId) {
            R.id.save -> {
                val intent = Intent(this, LastClick::class.java)
                startActivity(intent)
                return true
            }
            else -> return super.onOptionsItemSelected(item)
        }
    }
}
package com.example.core3

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import android.widget.Toast
import androidx.core.content.ContextCompat
import androidx.recyclerview.widget.RecyclerView

class CountryAdapter(private val country: List<Country>) : RecyclerView.Adapter<CountryAdapter.ViewHolder>() {
    private val top10Countries = getTop10CountriesWithHighestGoldMedal(country)
    override fun getItemCount(): Int = country.size
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val layoutInflater = LayoutInflater.from(parent.context)
        val view = layoutInflater.inflate(R.layout.country_list, parent, false) as View
        return ViewHolder(view)

    }


    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val country = country[position]
        val isTop10 = isTop10Country(country, top10Countries)
        holder.bind(country, isTop10)
    }


    inner class ViewHolder( v: View) : RecyclerView.ViewHolder(v), View.OnClickListener {
        var name = v.findViewById<TextView>(R.id.Name)
        val medal = v.findViewById<TextView>(R.id.Medal)

        init {
            // Set click listener on the nameTextView
            name.setOnClickListener(this)
        }
        override fun onClick(v: View?) {
            // Get the position of the clicked item
            val position = adapterPosition
            // Check that the position is valid (i.e., not RecyclerView.NO_POSITION)
            if (position != RecyclerView.NO_POSITION) {
                // Get the corresponding Country object from the list
                val country = country[position]

                // Save the country name to SharedPreferences
                val sharedPreferences = itemView.context.getSharedPreferences("myPreferences", Context.MODE_PRIVATE)
                val editor = sharedPreferences.edit()
                editor.putString("countryname", country.name)
                editor.putString("code",country.code)
                editor.apply()

                // Show a toast message with the country name
                val message = "${country.name} won ${country.golden} gold medals"
                Toast.makeText(itemView.context, message, Toast.LENGTH_SHORT).show()
            }
        }
        fun bind(item: Country, isTop10: Boolean) {
            name.text = item.name
            medal.text = item.golden.toString()
            if (isTop10) {
                itemView.setBackgroundColor(ContextCompat.getColor(itemView.context, R.color.purple_500))
            } else {
                itemView.setBackgroundColor(ContextCompat.getColor(itemView.context, android.R.color.transparent))
            }


        }
    }
    private fun isTop10Country(country: Country, top10Countries: List<Country>): Boolean {
        return top10Countries.contains(country)
    }
    private fun getTop10CountriesWithHighestGoldMedal(countryList: List<Country>): List<Country> {
        val top10Countries = mutableListOf<Country>()
        // Find the country with the highest gold medal count
        var highestGoldCountCountry = countryList.first()
        for (country in countryList) {
            if (country.golden > highestGoldCountCountry.golden) {
                highestGoldCountCountry = country
            }
        }
        // Add the country with the highest gold medal count to the top 10 list
        top10Countries.add(highestGoldCountCountry)
        // Find the next 9 countries with the highest gold medal counts
        for (i in 1 until 10) {
            var nextHighestGoldCountCountry = countryList.first()
            for (country in countryList) {
                if (!top10Countries.contains(country) && country.golden > nextHighestGoldCountCountry.golden) {
                    nextHighestGoldCountCountry = country
                }
            }
            top10Countries.add(nextHighestGoldCountCountry)
        }
        return top10Countries
    }
}


package au.edu.swin.sdmd.w03_calculations

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity

import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.RadioButton
import android.widget.TextView

class MainActivity : AppCompatActivity() {
    var operator = "plus";
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val number1 = findViewById<EditText>(R.id.number1)// get value from input
        val number2 = findViewById<EditText>(R.id.number2)

        val equals = findViewById<Button>(R.id.equals)
        val answer = findViewById<TextView>(R.id.answer)




        equals.setOnClickListener {

            val result = when(operator)
            {
                "plus" -> add(number1.text.toString(), number2.text.toString())
                "multiply" -> mul(number1.text.toString(), number2.text.toString())

                else -> {add(number1.text.toString(), number2.text.toString())}
            }
            answer.setText(getString(R.string.result)+ result)
            // TODO: show result on the screen
        }
    }
     fun onRadioButtonClicked(view: View) {
        if (view is RadioButton) {
            // Is the button now checked?
            val checked = view.isChecked

            // Check which radio button was clicked
            when (view.getId()) {
                R.id.radioMul ->
                    if (checked) {
                        operator = "multiply"

                    }
                R.id.radioPlus ->
                    if (checked) {
                        operator ="plus"
                    }
            }
        }
    }


    // adds two numbers together
    private fun add(number1: String, number2: String): Int{
        return number1.toInt() + number2.toInt()
    }
    private fun mul(number1: String, number2: String):Int {
        return number1.toInt() * number2.toInt()

    }

}
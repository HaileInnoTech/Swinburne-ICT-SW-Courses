

public class Clock
{
	private Counter minute;
	private Counter second;
	private Counter hours;

	public Clock()
	{
		minute = new Counter("minutes");
		second = new Counter("seconds");
		hours = new Counter("hours");

	}

	public final void Reset()
	{
		minute.Reset();
		second.Reset();
		hours.Reset();
	}
	public final String getReadTime()
	{
		return String.format("%1$02d:%2$02d:%3$02d", hours.getCount(), minute.getCount(), second.getCount());
	}

	public final void Tick()
	{
		if (second.getCount() < 59)
		{
			second.Increasement();
		}
		else
		{
			second.Reset();
			if (minute.getCount() < 59)
			{
				minute.Increasement();
			}
			else
			{
				minute.Reset();
				if (hours.getCount() == 23)
				{
					hours.Reset();
				}
				else
				{
					hours.Increasement();
				}
			}
		}
	}

}

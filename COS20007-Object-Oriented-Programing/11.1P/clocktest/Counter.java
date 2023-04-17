
public class Counter {

	private int _count;
	private String _name;

	public final int getCount() {
		return _count;
	}

	public final String getName() {
		return _name;
	}

	public final void setName(String value) {
		_name = value;
	}

	public Counter(String name) {
		_name = name;
		_count = 0;
	}

	public final void Increasement() {
		_count++;
	}

	public final void Reset() {
		_count = 0;
	}
}


public class Program {
	public static void main(String args[]) {

		Clock timeKeeper = new Clock();
		for (int i = 0; i < 60 * 60 * 24; i++) {
			System.out.println(timeKeeper.getReadTime());
			timeKeeper.Tick();
		}

	}
}

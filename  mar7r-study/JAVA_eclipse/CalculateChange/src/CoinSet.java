import java.util.HashMap;
import java.util.Map;


public class CoinSet {
	Map<Coin, Integer> coins;

	public CoinSet() {
		coins = new HashMap<Coin, Integer>();
	}

	public void add(Coin coin) {
		int coinCount = 0;
		if(coins.containsKey(coin))
			coinCount = coins.get(coin);
		
		coins.put(coin, coinCount++);
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((coins == null) ? 0 : coins.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		CoinSet other = (CoinSet) obj;
		if (coins == null) {
			if (other.coins != null)
				return false;
		} else if (!coins.equals(other.coins))
			return false;
		return true;
	}
}

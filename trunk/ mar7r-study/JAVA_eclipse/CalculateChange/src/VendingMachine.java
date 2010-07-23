import java.util.ArrayList;
import java.util.List;


public class VendingMachine {

	private int changes;
	private List<Coin> coins;
	
	public VendingMachine() {
		coins = new ArrayList<Coin>();
		coins.add(new Coin(500));
		coins.add(new Coin(100));
		coins.add(new Coin(50));
		coins.add(new Coin(10));
	}

	public void putCoins(int coins) {
		this.changes += coins;
	}

	public String getChangeAmount() {
		return String.format("%d", changes);
	}

	public void selectDrink(Drink drink) {
		changes -= drink.getValue();
	}

	public CoinSet getChangeCoinSet() {
		CoinSet coinSet = new CoinSet();
		for (Coin coin : coins) {
			addCoinToCoinSet(coinSet, coin);
		}
		return coinSet;
	}

	private void addCoinToCoinSet(CoinSet coinSet, Coin coin) {
		while(changes >= coin.getValue())
		{
			changes -= coin.getValue();
			coinSet.add(coin);
		}
	}

}

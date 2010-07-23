import static org.junit.Assert.*;

import org.junit.Test;



public class TestCalculateChange {
	/**
	 * �ܾ�Ȯ�� �׽�Ʈ	
	 * @throws Exception
	 */
	@Test	
	public void testGetChangeAmount() throws Exception {
		VendingMachine machine = new VendingMachine();
		machine.putCoins(100);
		assertEquals("���� ���Աݾ� 100", 
				"100", machine.getChangeAmount());
		machine.putCoins(500);
		assertEquals("�߰� ���Աݾ� 500", 
				"600", machine.getChangeAmount());
	}
	
	/**
	 * �Ž����� �׽�Ʈ
	 */
	@Test
	public void testReturnChangeCoinSet_Coins650() throws Exception {
		VendingMachine machine = new VendingMachine();
		machine.putCoins(1000);
		machine.selectDrink(new Drink("Cola", 650));
		
		CoinSet expectedCoinSet = new CoinSet();
		expectedCoinSet.add(new Coin(100));
		expectedCoinSet.add(new Coin(100));
		expectedCoinSet.add(new Coin(100));
		expectedCoinSet.add(new Coin(50));
		assertEquals("1000�� ���� �� 650�� ���� ����", 
				expectedCoinSet, machine.getChangeCoinSet());
	}
	
	/**
	 * �Ž����� �׽�Ʈ
	 */
	@Test
	public void testReturnChangeCoinSet_OneCoin() throws Exception {
		VendingMachine machine = new VendingMachine();
		machine.putCoins(500);
		machine.selectDrink(new Drink("Cola", 450));
		
		CoinSet expectedCoinSet = new CoinSet();
		expectedCoinSet.add(new Coin(50));
		assertEquals("500�� ���� �� 450�� ���� ����", 
				expectedCoinSet, machine.getChangeCoinSet());
	}	
}

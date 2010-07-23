import static org.junit.Assert.*;

import org.junit.Test;



public class TestCalculateChange {
	/**
	 * 잔액확인 테스트	
	 * @throws Exception
	 */
	@Test	
	public void testGetChangeAmount() throws Exception {
		VendingMachine machine = new VendingMachine();
		machine.putCoins(100);
		assertEquals("동전 투입금액 100", 
				"100", machine.getChangeAmount());
		machine.putCoins(500);
		assertEquals("추가 투입금액 500", 
				"600", machine.getChangeAmount());
	}
	
	/**
	 * 거스름돈 테스트
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
		assertEquals("1000원 투입 후 650원 음료 선택", 
				expectedCoinSet, machine.getChangeCoinSet());
	}
	
	/**
	 * 거스름돈 테스트
	 */
	@Test
	public void testReturnChangeCoinSet_OneCoin() throws Exception {
		VendingMachine machine = new VendingMachine();
		machine.putCoins(500);
		machine.selectDrink(new Drink("Cola", 450));
		
		CoinSet expectedCoinSet = new CoinSet();
		expectedCoinSet.add(new Coin(50));
		assertEquals("500원 투입 후 450원 음료 선택", 
				expectedCoinSet, machine.getChangeCoinSet());
	}	
}

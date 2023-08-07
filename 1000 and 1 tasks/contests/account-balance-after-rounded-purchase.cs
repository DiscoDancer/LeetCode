    public int AccountBalanceAfterPurchase(int purchaseAmount)
    {
        var r = purchaseAmount % 10;
        var nor = purchaseAmount - r;
        var result = nor + (r < 5 ? 0 : 10);
        return 100 - result;
    }
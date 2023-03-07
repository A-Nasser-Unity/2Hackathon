using UnityEngine;
using Thirdweb;
using System.Collections.Generic;

[System.Serializable]
public enum Chain
{
    Ethereum = 1,
    Goerli = 5,
    Polygon = 137,
    Mumbai = 80001,
    Fantom = 250,
    FantomTestnet = 4002,
    Avalanche = 43114,
    AvalancheTestnet = 43113,
    Optimism = 10,
    OptimismGoerli = 420,
    Arbitrum = 42161,
    ArbitrumGoerli = 421613,
    Binance = 56,
    BinanceTestnet = 97
}

public class ThirdwebManager : MonoBehaviour
{
    [Header("SETTINGS")]
    public Chain chain = Chain.FantomTestnet;
    public List<Chain> supportedNetworks;

    public Dictionary<Chain, string> chainIdentifiers = new Dictionary<Chain, string>
    {
        {Chain.Ethereum, "ethereum"},
        {Chain.Goerli, "goerli"},
        {Chain.Polygon, "polygon"},
        {Chain.Mumbai, "mumbai"},
        {Chain.Fantom, "fantom"},
        {Chain.FantomTestnet, "testnet"},
        {Chain.Avalanche, "avalanche"},
        {Chain.AvalancheTestnet, "avalanche-testnet"},
        {Chain.Optimism, "optimism"},
        {Chain.OptimismGoerli, "optimism-goerli"},
        {Chain.Arbitrum, "arbitrum"},
        {Chain.ArbitrumGoerli, "arbitrum-goerli"},
        {Chain.Binance, "binance"},
        {Chain.BinanceTestnet, "binance-testnet"},
    };

    public ThirdwebSDK SDK;

    public static ThirdwebManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

#if !UNITY_EDITOR
        SDK = new ThirdwebSDK("https://fantom-testnet.rpc.thirdweb.com", new ThirdwebSDK.Options() {
            gasless = new ThirdwebSDK.GaslessOptions() {
                    openzeppelin = new ThirdwebSDK.OZDefenderOptions() {
                        relayerUrl = "https://api.defender.openzeppelin.com/autotasks/c48891ff-a56b-43b0-9d9e-37708b9064f5/runs/webhook/8db4ba89-3c75-4a75-9f0e-98d36b4337a3/HUh8nk6vax7WmuiJAmkFuQ"
                    }
            }
        });
#endif
    }
}
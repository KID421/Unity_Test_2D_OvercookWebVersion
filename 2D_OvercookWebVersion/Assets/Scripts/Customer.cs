using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    #region 欄位
    [Header("訂單種類")]
    public Sprite[] sprOrder;
    [Header("金幣")]
    public Sprite sprCoin;

    /// <summary>
    /// 訂單 - 圖片元件
    /// </summary>
    private Image imgOrder;
    /// <summary>
    /// 訂單 - 按鈕元件
    /// </summary>
    private Button btnOrder;
    /// <summary>
    /// 訂單編號
    /// </summary>
    private int indexOrder;
    /// <summary>
    /// 老闆
    /// </summary>
    private Boss boss;
    #endregion

    #region 事件
    private void Start()
    {
        imgOrder = transform.GetChild(0).Find("訂單").GetComponent<Image>();
        btnOrder = imgOrder.GetComponent<Button>();
        btnOrder.onClick.AddListener(ClickOrder);
        boss = GameObject.Find("老闆").GetComponent<Boss>();

        RandomOrder();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 隨機訂單
    /// </summary>
    private void RandomOrder()
    {
        indexOrder = Random.Range(0, sprOrder.Length);
        imgOrder.sprite = sprOrder[indexOrder];
    }

    /// <summary>
    /// 點擊訂單
    /// </summary>
    private void ClickOrder()
    {
        boss.GetOrder(indexOrder, transform);
    }

    /// <summary>
    /// 取得餐點
    /// </summary>
    public void GetMeal()
    {
        imgOrder.sprite = sprCoin;
    }
    #endregion
}

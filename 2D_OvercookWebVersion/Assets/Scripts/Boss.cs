using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    #region 欄位
    [Header("餐點位置")]
    public Transform[] traMeals;
    [Header("移動速度")]
    public float speed = 0.2f;

    /// <summary>
    /// 客人的位置
    /// </summary>
    private Transform traCustomer;
    #endregion

    #region 事件
    private void Start()
    {
    }
    #endregion

    #region 方法
    /// <summary>
    /// 取得訂單
    /// </summary>
    /// <param name="indexOrder">訂單編號</param>
    public void GetOrder(int indexOrder, Transform traCustomer)
    {
        print("訂單編號" + indexOrder);

        this.traCustomer = traCustomer;
        StartCoroutine(MoveToMeal(traMeals[indexOrder]));
    }

    /// <summary>
    /// 前往訂單位置
    /// </summary>
    /// <param name="traMeal"></param>
    private IEnumerator MoveToMeal(Transform traMeal)
    {
        yield return StartCoroutine(MoveToObject(traMeal));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(MoveToCustomer(traCustomer));
    }

    /// <summary>
    /// 前往客人位置
    /// </summary>
    /// <param name="traCustomer">客人</param>
    private IEnumerator MoveToCustomer(Transform traCustomer)
    {
        yield return StartCoroutine(MoveToObject(traCustomer));
        yield return new WaitForSeconds(0.5f);
        traCustomer.GetComponent<Customer>().GetMeal();
    }
    
    /// <summary>
    /// 前往指定物件
    /// </summary>
    /// <param name="traget">指定物件</param>
    private IEnumerator MoveToObject(Transform traget)
    {
        while (Vector3.Distance(transform.position, traget.position) >= 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, traget.position, speed);
            yield return new WaitForSeconds(0.02f);
        }
    }
    #endregion
}

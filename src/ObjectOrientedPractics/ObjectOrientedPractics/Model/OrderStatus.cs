namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит перечисление статусов заказа.
    /// </summary>
    public enum OrderStatus
    {
        New,
        Processing,
        Assembly,
        Sent,
        Delivered,
        Returned,
        Abandoned
    }
}

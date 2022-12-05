namespace ObjectOrientedPractics.Model.Enums
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

using OmegaSportExplorerClub.Interfaces;
namespace OmegaSportExplorerClub.src.Database_entity_class
{
    /// <summary>
    /// Represents a registration card of player
    /// </summary>
    public class Card:InterfaceId
    {
        private int db_id;
        private int cardNumber;
        private DateTime expirationDate;

        /// <summary>
        /// Initializes a new instance of the Card class with the specified database ID, card number, and expiration date.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <param name="expirationDate">The expiration date of the card.</param>
        public Card(int cardNumber, DateTime expirationDate)
        {
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
        }
        /// <summary>
        /// Initializes a new instance of the Card class with default values.
        /// </summary>
        public Card()
        {
            
        }
        public int DB_ID { get => db_id; set => db_id = value; }
        public int CardNumber { get => cardNumber; set => cardNumber = value; }
        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = value; }
    }
}

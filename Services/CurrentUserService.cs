namespace IT59_Pharmacy.Services {
    public class CurrentUserService {
        private int? _currentUserId;

        public int? getCurrentUserId() {
            return _currentUserId;
        }

        public void setCurrentUserId(int userId) {
            _currentUserId = userId;
        }

        public void ClearCurrentUser() {
            _currentUserId = null;
        }
    }
}
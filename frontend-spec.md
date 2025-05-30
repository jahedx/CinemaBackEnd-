# Cinema Ticket Booking Frontend Specification

## Technology Stack

- React with TypeScript
- Material-UI (MUI) for UI components
- React Router for navigation
- Axios for API calls
- React Query for data fetching and caching
- Formik & Yup for form handling and validation
- JWT authentication

## Core Features

### Authentication

- Login page with username/password
- Registration page with required fields
- JWT token storage and management
- Protected routes based on user roles
- Token refresh mechanism

### User Roles

1. Customer

   - Browse movies
   - Book tickets
   - View and manage reservations
   - Write reviews
   - View notifications
   - Make payments

2. Cinema Manager

   - All Customer features
   - Manage cinemas
   - Manage halls
   - Manage screenings
   - Manage seats
   - View reports

3. Admin
   - All Cinema Manager features
   - Manage users
   - Manage movies
   - System-wide settings

## Page Structure

### Public Pages

- Home/Landing page
- Movie listings
- Movie details
- Login
- Register

### Protected Pages

- User Dashboard
- Movie Management
- Cinema Management
- Hall Management
- Screening Management
- Seat Management
- Reservation Management
- Payment Processing
- Review Management
- Notification Center
- User Management (Admin only)

## API Integration

### Authentication Endpoints

- POST /api/Auth/register
- POST /api/Auth/login
- POST /api/Auth/refresh-token

### Movie Endpoints

- GET /api/Movie
- GET /api/Movie/{id}
- POST /api/Movie
- PUT /api/Movie/{id}
- DELETE /api/Movie/{id}

### Cinema Endpoints

- GET /api/Cinema
- GET /api/Cinema/{id}
- POST /api/Cinema
- PUT /api/Cinema/{id}
- DELETE /api/Cinema/{id}

### Hall Endpoints

- GET /api/Hall
- GET /api/Hall/{id}
- POST /api/Hall
- PUT /api/Hall/{id}
- DELETE /api/Hall/{id}

### Screening Endpoints

- GET /api/Screening
- GET /api/Screening/{id}
- POST /api/Screening
- PUT /api/Screening/{id}
- DELETE /api/Screening/{id}

### Seat Endpoints

- GET /api/Seat
- GET /api/Seat/{id}
- POST /api/Seat
- PUT /api/Seat/{id}
- DELETE /api/Seat/{id}

### Reservation Endpoints

- GET /api/Reservation
- GET /api/Reservation/{id}
- POST /api/Reservation
- PUT /api/Reservation/{id}
- DELETE /api/Reservation/{id}

### Ticket Endpoints

- GET /api/Ticket
- GET /api/Ticket/{id}
- POST /api/Ticket
- PUT /api/Ticket/{id}
- DELETE /api/Ticket/{id}

### Payment Endpoints

- GET /api/Payment
- GET /api/Payment/{id}
- POST /api/Payment
- PUT /api/Payment/{id}
- DELETE /api/Payment/{id}

### Review Endpoints

- GET /api/Review
- GET /api/Review/{id}
- POST /api/Review
- PUT /api/Review/{id}
- DELETE /api/Review/{id}

### Notification Endpoints

- GET /api/Notification
- GET /api/Notification/{id}
- GET /api/Notification/user/{userId}
- POST /api/Notification
- PUT /api/Notification/{id}
- PUT /api/Notification/{id}/mark-as-read
- DELETE /api/Notification/{id}

### User Endpoints

- GET /api/User
- GET /api/User/{id}
- POST /api/User
- PUT /api/User/{id}
- DELETE /api/User/{id}

## UI/UX Requirements

### Layout

- Responsive design
- Navigation sidebar for authenticated users
- Header with user info and notifications
- Footer with basic information

### Components

- Movie cards with posters and details
- Seat selection grid
- Calendar for screening dates
- Payment form
- Review form with star rating
- Notification center
- User profile management
- Admin dashboard with statistics

### Features

- Real-time seat availability
- Search and filter movies
- Sort options for listings
- Pagination for long lists
- Form validation
- Error handling and notifications
- Loading states
- Confirmation dialogs for important actions

## State Management

- JWT token storage
- User session management
- Cart/booking state
- Form states
- API response caching
- Error states

## Security

- JWT token handling
- Role-based access control
- Secure password handling
- Protected routes
- API error handling
- Input validation

## Performance

- Lazy loading of components
- Image optimization
- API response caching
- Pagination for large datasets
- Optimistic updates

## Testing

- Unit tests for components
- Integration tests for features
- API integration tests
- Authentication flow tests
- Role-based access tests

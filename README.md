
## Used framworks 
  * dot net core 3.1
  * Ef core 
  
## Database
  * SQL Server 
  
# About the solution 

this is a solution of WakecapBusReservation Task buit using .Net core 3.1 with clean architecture.
   * Solution consits of 4 projects
   
         * Api project contains all controllers and client view models
		 
         * Application layer holds the business logic. All the business logic has been be written 
		   in this layer.	
		 
         * Domain/Core Layer contains the enterprise logic, like the entities and their specifications.		 
		 
		 * Infrastracture layer contais  all the database migrations and database context Objects. 
		   In this layer, we have the repositories of the domain model objects. 
   
   * Apis are secured with built-in identity server4 using JWT schema 
   
   * swgger interface is configured to provide full api documentation with controller and actions request, response and http method  
   
   * custom exception middleware has been implemented to centralize exception handling and error response

   * latest migration is being applied while app start 
   
   * All pre defined assumtion of the solution is being seeded  while app start
   
   ## Patterns used
   * Unite of work 
   
   * Generic repository 
   
   * dependency injection using built-in service collection of dot net core
   
   * same factory pattern idea has been used in Exception type  ```csharp InvalidTripBusVsTripRouteException.cs ```
   
# APIs in this solution 

   * All Apis documented using swagger and the follwing is a qiuck description about how  it works.

   ## Register
       * first we need to register user in order to access secured api with registered user token.  
	   
       * wrapping identity server create to add user in db. 
	   
	   * All request view model are required.
	   
	   * Password must has at least one upper letter, lower letter and special character.
	   
	   * Email must be email formatted.
	   
	   * Request:
       {
	     //username
		 public string UserName { get; set; }
		 //user email
		 public string Email { get; set; }
		 //user password
		 public string Password { get; set; }
       }

       * Response:
       {
	      // user login email
		  public string Emial { get; set; }
		  //User login password
		  public string UserName { get; set; }
		  // generated token 
		  public string Token { get; set; }
       }

   ## Login 
   
       * wrapping identity server login to sign user in and generate token.
       
	   * Request:
       {
	      //user login email
		  public string Email { get; set; }
		  //user login password 
		  public string Password { get; set; }
       }

	* Response:
	   {
	      // user login email
		  public string Emial { get; set; }
		  //User login password
		  public string UserName { get; set; }
		  // generated token
		  public string Token { get; set; }
	   }

   ## Create Trip 
    * use this action in order to creating trip to be ready for user reservations. 
       
	* Request:
       {
	      //trip bus id 
	      public string BusId { get; set; }
	      //trip route id 
	      public string RouteId { get; set; }
	      //trip date time 
	      public DateTime DateTime { get; set; }
	      //trip ticket price 
	      public decimal TicketPrice { get; set; }
	      //trip price currency 
	      public string Currency { get; set; }
       }
	* Response:
       {
	      public string Created { get; set; }
       }
   ## Create ticket 
    * this action used reserve seats in a trip   
	  
    * Request:
	   {
	      //user login email 
		  public string UserEmail { get; set; }
		  //trip route 
		  public string TripRoute { get; set; }
		  //seats to be reserved 
		  public List<string> Seats { get; set; }
       }
	* Response:
	   {
	      //user login emai
		  public string UserEmail { get; set; }
		  //user bus id
		  public string BusId { get; set; }
		  //total ticket price 
		  public string Price { get; set; }
		  //created tickets 
		  public List<CreateTicketSuccessViewModel> Tickets { get; set; }
       }

	* CreateTicketSuccessViewModel
	   {
	      //generated ticket id 
		  public int TicketId { get; set; }
		  //Seat id 
		  public string SeatId { get; set; }
	   }

   ## GetFrequentTripForUser 
	
    * this action used to retrieve the most frequent route reserved by each user
	   
    * this action does not accept any parameters 

	* Response:
	   {
	      //user login email
		  public string UserEmail { get; set; }
		  //user bus id
		  public string BusId { get; set; }
		  //total ticket price 
		  public string Price { get; set; }
		  //created tickets 
		  public List<CreateTicketSuccessViewModel> Tickets { get; set; }
       }
	  CreateTicketSuccessViewModel
	   {
	      //user login email		
		  public string Email { get; set; }
		  //most reserved route 
		  public string FrequentBook { get; set; }
	   }




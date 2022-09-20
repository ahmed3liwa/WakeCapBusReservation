
## Used framworks 
  * dot net core 3.1
  * Ef core 
  
## Database
  * SQL Server 
  
# About the solution 

this is a solution of WakecapBusReservation Task buit using .Net core 3.1 with clean architecture.
   * Solution consits of 4 projects
   
         * Api project contains all controlles and client view models
		 
         * Application layer holds the business logic. All the business logic has been be written in this layer.	
		 
         * Domain/Core Layer contains the enterprise logic, like the entities and their specifications.		 
		 
		 * Infrastracture layer contais  all the database migrations and database context Objects. In this layer, we have the repositories of the domain model objects. 
   
   * Apis is secured with built-in identity server4 using JWT schema 
   
   * swgger interface is configured to provide full api documentation with controlles and actions request, response and http method  
   
   * custom exception middleware has been implemented to centralize exception handling and error response

   * latest migration is being applied while app start 
   
   * All pre defined assumtion of the solution is being seeded  while app start
   
   ## Patterns used
   * Unite of work 
   
   * Generic repository 
   
   * dependncy injection using built-in service collection of dot core
   
   * same factory pttern idea has been used in Exception type  ```csharp InvalidTripBusVsTripRouteException.cs ```
   
# APIs in this solution 

   * All Apis documented using swagger and the follwing is a qiuck dicription about how  it works.

   ## Register
       * first we need to register user in order to access secured api with regitered user token.  
	   
       * wrapping idintiy server create to add user in db. 
	   
       * Request:
       {
	     //username
		 public string DisplayName { get; set; }
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
   
       * wrapping idintiy server login to sign user in and generate token. 
       
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
    * this action used in creating trip to be ready for user reservations. 
       
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
       
		 bool tripCreated
       
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
	
    * this action used to retrive the most frequent route reserved by each user    
	   
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




#Usings
Namespace "Views.Shared"

#Initialization
Views.Shared.Logout = ->
	this._LogOffBtn = null
	
#Implementation
class Views.Shared.Logout 
	init: -> 
		parent = this;
		this._LogOffBtn = $("#logOffBtn")
		
		this._LogOffBtn.on "click", (event) ->		
			bootbox.dialog 
				message: "Are you sure you want to log out?",
				buttons: 
					cancel: 
						label: "No"
						callback: ->
							event.preventDefault()
					confirm: 
						label: "Yes"	
						callback: ->
							$("#logoutForm").submit()
			event.preventDefault()					
			
$ -> 
	logout = new Views.Shared.Logout
	
	logout.init()
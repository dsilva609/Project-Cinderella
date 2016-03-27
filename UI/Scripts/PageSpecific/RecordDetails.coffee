#Usings
Namespace "Views.Record"

#Initialization
Views.Record.Details = ->

#Implementation
class Views.Record.Details
	init: ->
		$('[id=recordDeleteBtn]').on "click", ->
			ID = $(this).data "id"
	
			bootbox.dialog 
				message: "Are you sure you want to remove this record?",
				buttons: 
					cancel: 
						label: "No"
					confirm: 
						label: "Yes"
						className: "btn-danger"
						callback: ->
							window.location.href = deleteUrl + "/" + ID
			return false
$ ->
	details = new Views.Record.Details
	details.init()
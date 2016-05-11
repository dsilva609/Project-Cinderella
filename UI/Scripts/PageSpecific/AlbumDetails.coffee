#Usings
Namespace "Views.Album"

#Initialization
Views.Album.Details = ->

#Implementation
class Views.Album.Details
	init: ->
#		$('[id=albumDeleteBtn]').on "click", ->
#			ID = $(this).data "id"
#	
#			bootbox.dialog 
#				message: "Are you sure you want to remove this album?",
#				buttons: 
#					cancel: 
#						label: "No"
#					confirm: 
#						label: "Yes"
#						className: "btn-danger"
#						callback: ->
#							window.location.href = deleteUrl + "/" + ID
#			return false
$ ->
	details = new Views.Album.Details
	details.init()
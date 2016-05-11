#Usings
Namespace "Views.Album"

#Initialization
Views.Album.Edit = ->

#Implementation
class Views.Album.Edit
	init: ->
#		$("#btnDelete").on "click", ->
#			ID = $(this).data "id"
#			deleteUrl = $(this).data "deleteurl"
#			
#			bootbox.dialog 
#				message: "Are you sure you want to delete this album?",
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
	edit = new Views.Album.Edit
	edit.init()
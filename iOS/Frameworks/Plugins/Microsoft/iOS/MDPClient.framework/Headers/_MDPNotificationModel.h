//
//  _MDPNotificationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPNotificationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPNotificationModelAttributes {
	__unsafe_unretained NSString *bodyText;
	__unsafe_unretained NSString *idNotification;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *imageLinkUrl;
	__unsafe_unretained NSString *imageUrl;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *notificationDate;
	__unsafe_unretained NSString *readed;
	__unsafe_unretained NSString *text;
} MDPNotificationModelAttributes;

extern const struct MDPNotificationModelRelationships {
	__unsafe_unretained NSString *pagedNotificationResults;
} MDPNotificationModelRelationships;

@class MDPPagedNotificationsModel;

@interface _MDPNotificationModel : NSManagedObject

@property (nonatomic, strong) NSString* bodyText;

//- (BOOL)validateBodyText:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idNotification;

//- (BOOL)validateIdNotification:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* imageLinkUrl;

//- (BOOL)validateImageLinkUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* imageUrl;

//- (BOOL)validateImageUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* notificationDate;

//- (BOOL)validateNotificationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* readed;

@property (atomic) BOOL readedValue;
- (BOOL)readedValue;
- (void)setReadedValue:(BOOL)value_;

//- (BOOL)validateReaded:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* text;

//- (BOOL)validateText:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *pagedNotificationResults;

- (NSMutableSet*)pagedNotificationResultsSet;

@end

@interface _MDPNotificationModel (PagedNotificationResultsCoreDataGeneratedAccessors)
- (void)addPagedNotificationResults:(NSSet*)value_;
- (void)removePagedNotificationResults:(NSSet*)value_;
- (void)addPagedNotificationResultsObject:(MDPPagedNotificationsModel*)value_;
- (void)removePagedNotificationResultsObject:(MDPPagedNotificationsModel*)value_;
@end

@interface _MDPNotificationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveBodyText;
- (void)setPrimitiveBodyText:(NSString*)value;

- (NSString*)primitiveIdNotification;
- (void)setPrimitiveIdNotification:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSString*)primitiveImageLinkUrl;
- (void)setPrimitiveImageLinkUrl:(NSString*)value;

- (NSString*)primitiveImageUrl;
- (void)setPrimitiveImageUrl:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDate*)primitiveNotificationDate;
- (void)setPrimitiveNotificationDate:(NSDate*)value;

- (NSNumber*)primitiveReaded;
- (void)setPrimitiveReaded:(NSNumber*)value;

- (BOOL)primitiveReadedValue;
- (void)setPrimitiveReadedValue:(BOOL)value_;

- (NSString*)primitiveText;
- (void)setPrimitiveText:(NSString*)value;

- (NSMutableSet*)primitivePagedNotificationResults;
- (void)setPrimitivePagedNotificationResults:(NSMutableSet*)value;

@end

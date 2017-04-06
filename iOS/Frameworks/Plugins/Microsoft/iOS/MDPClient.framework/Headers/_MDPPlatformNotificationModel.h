//
//  _MDPPlatformNotificationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPlatformNotificationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPlatformNotificationModelAttributes {
	__unsafe_unretained NSString *idClient;
	__unsafe_unretained NSString *idNotification;
	__unsafe_unretained NSString *idSendOrder;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *notificationDate;
	__unsafe_unretained NSString *onlyInbox;
	__unsafe_unretained NSString *tag;
} MDPPlatformNotificationModelAttributes;

extern const struct MDPPlatformNotificationModelRelationships {
	__unsafe_unretained NSString *body;
	__unsafe_unretained NSString *pagedPlatformNotificationsResults;
} MDPPlatformNotificationModelRelationships;

@class MDPBodyPlatformNotificationModel;
@class MDPPagedPlatformNotificationsModel;

@interface _MDPPlatformNotificationModel : NSManagedObject

@property (nonatomic, strong) NSString* idClient;

//- (BOOL)validateIdClient:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idNotification;

//- (BOOL)validateIdNotification:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* idSendOrder;

@property (atomic) int64_t idSendOrderValue;
- (int64_t)idSendOrderValue;
- (void)setIdSendOrderValue:(int64_t)value_;

//- (BOOL)validateIdSendOrder:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* notificationDate;

//- (BOOL)validateNotificationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* onlyInbox;

@property (atomic) BOOL onlyInboxValue;
- (BOOL)onlyInboxValue;
- (void)setOnlyInboxValue:(BOOL)value_;

//- (BOOL)validateOnlyInbox:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* tag;

//- (BOOL)validateTag:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *body;

- (NSMutableSet*)bodySet;

@property (nonatomic, strong) MDPPagedPlatformNotificationsModel *pagedPlatformNotificationsResults;

//- (BOOL)validatePagedPlatformNotificationsResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPlatformNotificationModel (BodyCoreDataGeneratedAccessors)
- (void)addBody:(NSSet*)value_;
- (void)removeBody:(NSSet*)value_;
- (void)addBodyObject:(MDPBodyPlatformNotificationModel*)value_;
- (void)removeBodyObject:(MDPBodyPlatformNotificationModel*)value_;
@end

@interface _MDPPlatformNotificationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdClient;
- (void)setPrimitiveIdClient:(NSString*)value;

- (NSString*)primitiveIdNotification;
- (void)setPrimitiveIdNotification:(NSString*)value;

- (NSNumber*)primitiveIdSendOrder;
- (void)setPrimitiveIdSendOrder:(NSNumber*)value;

- (int64_t)primitiveIdSendOrderValue;
- (void)setPrimitiveIdSendOrderValue:(int64_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDate*)primitiveNotificationDate;
- (void)setPrimitiveNotificationDate:(NSDate*)value;

- (NSNumber*)primitiveOnlyInbox;
- (void)setPrimitiveOnlyInbox:(NSNumber*)value;

- (BOOL)primitiveOnlyInboxValue;
- (void)setPrimitiveOnlyInboxValue:(BOOL)value_;

- (NSString*)primitiveTag;
- (void)setPrimitiveTag:(NSString*)value;

- (NSMutableSet*)primitiveBody;
- (void)setPrimitiveBody:(NSMutableSet*)value;

- (MDPPagedPlatformNotificationsModel*)primitivePagedPlatformNotificationsResults;
- (void)setPrimitivePagedPlatformNotificationsResults:(MDPPagedPlatformNotificationsModel*)value;

@end

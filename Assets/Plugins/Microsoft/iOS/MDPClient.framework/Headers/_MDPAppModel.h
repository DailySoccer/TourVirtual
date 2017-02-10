//
//  _MDPAppModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPAppModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPAppModelAttributes {
	__unsafe_unretained NSString *appId;
	__unsafe_unretained NSString *enablePushNotifications;
	__unsafe_unretained NSString *idClient;
	__unsafe_unretained NSString *idDevice;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *platformVersion;
	__unsafe_unretained NSString *pushNotificationHandler;
} MDPAppModelAttributes;

@interface _MDPAppModel : NSManagedObject

@property (nonatomic, strong) NSString* appId;

//- (BOOL)validateAppId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* enablePushNotifications;

@property (atomic) BOOL enablePushNotificationsValue;
- (BOOL)enablePushNotificationsValue;
- (void)setEnablePushNotificationsValue:(BOOL)value_;

//- (BOOL)validateEnablePushNotifications:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idClient;

//- (BOOL)validateIdClient:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idDevice;

//- (BOOL)validateIdDevice:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* platformVersion;

//- (BOOL)validatePlatformVersion:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* pushNotificationHandler;

//- (BOOL)validatePushNotificationHandler:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPAppModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAppId;
- (void)setPrimitiveAppId:(NSString*)value;

- (NSNumber*)primitiveEnablePushNotifications;
- (void)setPrimitiveEnablePushNotifications:(NSNumber*)value;

- (BOOL)primitiveEnablePushNotificationsValue;
- (void)setPrimitiveEnablePushNotificationsValue:(BOOL)value_;

- (NSString*)primitiveIdClient;
- (void)setPrimitiveIdClient:(NSString*)value;

- (NSString*)primitiveIdDevice;
- (void)setPrimitiveIdDevice:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitivePlatformVersion;
- (void)setPrimitivePlatformVersion:(NSString*)value;

- (NSString*)primitivePushNotificationHandler;
- (void)setPrimitivePushNotificationHandler:(NSString*)value;

@end

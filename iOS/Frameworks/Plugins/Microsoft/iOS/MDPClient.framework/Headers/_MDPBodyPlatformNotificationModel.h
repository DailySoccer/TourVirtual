//
//  _MDPBodyPlatformNotificationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPBodyPlatformNotificationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPBodyPlatformNotificationModelAttributes {
	__unsafe_unretained NSString *imageUrl;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *url;
} MDPBodyPlatformNotificationModelAttributes;

extern const struct MDPBodyPlatformNotificationModelRelationships {
	__unsafe_unretained NSString *platformNotificationBody;
	__unsafe_unretained NSString *text;
} MDPBodyPlatformNotificationModelRelationships;

@class MDPPlatformNotificationModel;
@class MDPLocaleDescriptionModel;

@interface _MDPBodyPlatformNotificationModel : NSManagedObject

@property (nonatomic, strong) NSString* imageUrl;

//- (BOOL)validateImageUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* url;

//- (BOOL)validateUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *platformNotificationBody;

- (NSMutableSet*)platformNotificationBodySet;

@property (nonatomic, strong) MDPLocaleDescriptionModel *text;

//- (BOOL)validateText:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPBodyPlatformNotificationModel (PlatformNotificationBodyCoreDataGeneratedAccessors)
- (void)addPlatformNotificationBody:(NSSet*)value_;
- (void)removePlatformNotificationBody:(NSSet*)value_;
- (void)addPlatformNotificationBodyObject:(MDPPlatformNotificationModel*)value_;
- (void)removePlatformNotificationBodyObject:(MDPPlatformNotificationModel*)value_;
@end

@interface _MDPBodyPlatformNotificationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveImageUrl;
- (void)setPrimitiveImageUrl:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveUrl;
- (void)setPrimitiveUrl:(NSString*)value;

- (NSMutableSet*)primitivePlatformNotificationBody;
- (void)setPrimitivePlatformNotificationBody:(NSMutableSet*)value;

- (MDPLocaleDescriptionModel*)primitiveText;
- (void)setPrimitiveText:(MDPLocaleDescriptionModel*)value;

@end

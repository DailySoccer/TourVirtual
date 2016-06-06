//
//  _MDPMenuAdvertisementModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMenuAdvertisementModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMenuAdvertisementModelAttributes {
	__unsafe_unretained NSString *idAdvertisement;
	__unsafe_unretained NSString *idPlaceholder;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *timeInSeconds;
} MDPMenuAdvertisementModelAttributes;

extern const struct MDPMenuAdvertisementModelRelationships {
	__unsafe_unretained NSString *menu;
} MDPMenuAdvertisementModelRelationships;

@class MDPMenuModel;

@interface _MDPMenuAdvertisementModel : NSManagedObject

@property (nonatomic, strong) NSString* idAdvertisement;

//- (BOOL)validateIdAdvertisement:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlaceholder;

//- (BOOL)validateIdPlaceholder:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* timeInSeconds;

@property (atomic) int16_t timeInSecondsValue;
- (int16_t)timeInSecondsValue;
- (void)setTimeInSecondsValue:(int16_t)value_;

//- (BOOL)validateTimeInSeconds:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *menu;

- (NSMutableSet*)menuSet;

@end

@interface _MDPMenuAdvertisementModel (MenuCoreDataGeneratedAccessors)
- (void)addMenu:(NSSet*)value_;
- (void)removeMenu:(NSSet*)value_;
- (void)addMenuObject:(MDPMenuModel*)value_;
- (void)removeMenuObject:(MDPMenuModel*)value_;
@end

@interface _MDPMenuAdvertisementModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdAdvertisement;
- (void)setPrimitiveIdAdvertisement:(NSString*)value;

- (NSString*)primitiveIdPlaceholder;
- (void)setPrimitiveIdPlaceholder:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveTimeInSeconds;
- (void)setPrimitiveTimeInSeconds:(NSNumber*)value;

- (int16_t)primitiveTimeInSecondsValue;
- (void)setPrimitiveTimeInSecondsValue:(int16_t)value_;

- (NSMutableSet*)primitiveMenu;
- (void)setPrimitiveMenu:(NSMutableSet*)value;

@end

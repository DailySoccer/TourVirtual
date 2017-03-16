//
//  _MDPPagedSubscriptionConfigurationBasicInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPagedSubscriptionConfigurationBasicInfoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPagedSubscriptionConfigurationBasicInfoModelAttributes {
	__unsafe_unretained NSString *callType;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *totalCount;
} MDPPagedSubscriptionConfigurationBasicInfoModelAttributes;

extern const struct MDPPagedSubscriptionConfigurationBasicInfoModelRelationships {
	__unsafe_unretained NSString *items;
	__unsafe_unretained NSString *pagedSubscriptionConfigurationBasicInfoRequest;
} MDPPagedSubscriptionConfigurationBasicInfoModelRelationships;

@class MDPSubscriptionConfigurationBasicInfoModel;
@class MDPPagedSubscriptionConfigurationBasicInfoRequestModel;

@interface _MDPPagedSubscriptionConfigurationBasicInfoModel : NSManagedObject

@property (nonatomic, strong) NSNumber* callType;

@property (atomic) int16_t callTypeValue;
- (int16_t)callTypeValue;
- (void)setCallTypeValue:(int16_t)value_;

//- (BOOL)validateCallType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalCount;

@property (atomic) int64_t totalCountValue;
- (int64_t)totalCountValue;
- (void)setTotalCountValue:(int64_t)value_;

//- (BOOL)validateTotalCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *items;

- (NSMutableSet*)itemsSet;

@property (nonatomic, strong) MDPPagedSubscriptionConfigurationBasicInfoRequestModel *pagedSubscriptionConfigurationBasicInfoRequest;

//- (BOOL)validatePagedSubscriptionConfigurationBasicInfoRequest:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPagedSubscriptionConfigurationBasicInfoModel (ItemsCoreDataGeneratedAccessors)
- (void)addItems:(NSSet*)value_;
- (void)removeItems:(NSSet*)value_;
- (void)addItemsObject:(MDPSubscriptionConfigurationBasicInfoModel*)value_;
- (void)removeItemsObject:(MDPSubscriptionConfigurationBasicInfoModel*)value_;
@end

@interface _MDPPagedSubscriptionConfigurationBasicInfoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveCallType;
- (void)setPrimitiveCallType:(NSNumber*)value;

- (int16_t)primitiveCallTypeValue;
- (void)setPrimitiveCallTypeValue:(int16_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveTotalCount;
- (void)setPrimitiveTotalCount:(NSNumber*)value;

- (int64_t)primitiveTotalCountValue;
- (void)setPrimitiveTotalCountValue:(int64_t)value_;

- (NSMutableSet*)primitiveItems;
- (void)setPrimitiveItems:(NSMutableSet*)value;

- (MDPPagedSubscriptionConfigurationBasicInfoRequestModel*)primitivePagedSubscriptionConfigurationBasicInfoRequest;
- (void)setPrimitivePagedSubscriptionConfigurationBasicInfoRequest:(MDPPagedSubscriptionConfigurationBasicInfoRequestModel*)value;

@end

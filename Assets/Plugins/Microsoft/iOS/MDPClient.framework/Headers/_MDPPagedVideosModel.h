//
//  _MDPPagedVideosModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPagedVideosModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPagedVideosModelAttributes {
	__unsafe_unretained NSString *callType;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *totalCount;
} MDPPagedVideosModelAttributes;

extern const struct MDPPagedVideosModelRelationships {
	__unsafe_unretained NSString *items;
	__unsafe_unretained NSString *pagedVideosRequest;
} MDPPagedVideosModelRelationships;

@class MDPVideoModel;
@class MDPPagedVideosRequestModel;

@interface _MDPPagedVideosModel : NSManagedObject

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

@property (nonatomic, strong) MDPPagedVideosRequestModel *pagedVideosRequest;

//- (BOOL)validatePagedVideosRequest:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPagedVideosModel (ItemsCoreDataGeneratedAccessors)
- (void)addItems:(NSSet*)value_;
- (void)removeItems:(NSSet*)value_;
- (void)addItemsObject:(MDPVideoModel*)value_;
- (void)removeItemsObject:(MDPVideoModel*)value_;
@end

@interface _MDPPagedVideosModel (CoreDataGeneratedPrimitiveAccessors)

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

- (MDPPagedVideosRequestModel*)primitivePagedVideosRequest;
- (void)setPrimitivePagedVideosRequest:(MDPPagedVideosRequestModel*)value;

@end

//
//  _MDPPagedVirtualGoodModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPagedVirtualGoodModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPagedVirtualGoodModelAttributes {
	__unsafe_unretained NSString *currentPage;
	__unsafe_unretained NSString *hasMoreResults;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *pageCount;
	__unsafe_unretained NSString *pageSize;
	__unsafe_unretained NSString *totalItems;
} MDPPagedVirtualGoodModelAttributes;

extern const struct MDPPagedVirtualGoodModelRelationships {
	__unsafe_unretained NSString *pagedVirtualGoodRequest;
	__unsafe_unretained NSString *results;
} MDPPagedVirtualGoodModelRelationships;

@class MDPPagedVirtualGoodRequestModel;
@class MDPVirtualGoodModel;

@interface _MDPPagedVirtualGoodModel : NSManagedObject

@property (nonatomic, strong) NSNumber* currentPage;

@property (atomic) int64_t currentPageValue;
- (int64_t)currentPageValue;
- (void)setCurrentPageValue:(int64_t)value_;

//- (BOOL)validateCurrentPage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* hasMoreResults;

@property (atomic) int64_t hasMoreResultsValue;
- (int64_t)hasMoreResultsValue;
- (void)setHasMoreResultsValue:(int64_t)value_;

//- (BOOL)validateHasMoreResults:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* pageCount;

@property (atomic) int64_t pageCountValue;
- (int64_t)pageCountValue;
- (void)setPageCountValue:(int64_t)value_;

//- (BOOL)validatePageCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* pageSize;

@property (atomic) int64_t pageSizeValue;
- (int64_t)pageSizeValue;
- (void)setPageSizeValue:(int64_t)value_;

//- (BOOL)validatePageSize:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalItems;

@property (atomic) int64_t totalItemsValue;
- (int64_t)totalItemsValue;
- (void)setTotalItemsValue:(int64_t)value_;

//- (BOOL)validateTotalItems:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedVirtualGoodRequestModel *pagedVirtualGoodRequest;

//- (BOOL)validatePagedVirtualGoodRequest:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSOrderedSet *results;

- (NSMutableOrderedSet*)resultsSet;

@end

@interface _MDPPagedVirtualGoodModel (ResultsCoreDataGeneratedAccessors)
- (void)addResults:(NSOrderedSet*)value_;
- (void)removeResults:(NSOrderedSet*)value_;
- (void)addResultsObject:(MDPVirtualGoodModel*)value_;
- (void)removeResultsObject:(MDPVirtualGoodModel*)value_;
@end

@interface _MDPPagedVirtualGoodModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveCurrentPage;
- (void)setPrimitiveCurrentPage:(NSNumber*)value;

- (int64_t)primitiveCurrentPageValue;
- (void)setPrimitiveCurrentPageValue:(int64_t)value_;

- (NSNumber*)primitiveHasMoreResults;
- (void)setPrimitiveHasMoreResults:(NSNumber*)value;

- (int64_t)primitiveHasMoreResultsValue;
- (void)setPrimitiveHasMoreResultsValue:(int64_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitivePageCount;
- (void)setPrimitivePageCount:(NSNumber*)value;

- (int64_t)primitivePageCountValue;
- (void)setPrimitivePageCountValue:(int64_t)value_;

- (NSNumber*)primitivePageSize;
- (void)setPrimitivePageSize:(NSNumber*)value;

- (int64_t)primitivePageSizeValue;
- (void)setPrimitivePageSizeValue:(int64_t)value_;

- (NSNumber*)primitiveTotalItems;
- (void)setPrimitiveTotalItems:(NSNumber*)value;

- (int64_t)primitiveTotalItemsValue;
- (void)setPrimitiveTotalItemsValue:(int64_t)value_;

- (MDPPagedVirtualGoodRequestModel*)primitivePagedVirtualGoodRequest;
- (void)setPrimitivePagedVirtualGoodRequest:(MDPPagedVirtualGoodRequestModel*)value;

- (NSMutableOrderedSet*)primitiveResults;
- (void)setPrimitiveResults:(NSMutableOrderedSet*)value;

@end
